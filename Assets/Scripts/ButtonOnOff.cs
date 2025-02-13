using System.Collections;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ButtonOnOff : MonoBehaviour
{
    [SerializeField] public Light _overLight;
    [SerializeField] private Animator _doorAnimator;
    public bool isOn;

    private void Start()
    {
        isOn = false;

        TurnOff();
    }

    public void ChangeButton()
    {
        isOn = !isOn;

        if (isOn)
        {
            if (_doorAnimator != null)
                StartCoroutine(PlayDoorAnimation("DoorOpen"));
            else if (_overLight != null)
                _overLight.enabled = true;
        }
        else
        {
            if (_doorAnimator != null)
                StartCoroutine(PlayDoorAnimation("DoorClose"));
            TurnOff();
        }

        Debug.Log("Botão pressionado! Estado: " + (isOn ? "Ligado" : "Desligado"));
    }

    private IEnumerator PlayDoorAnimation(string animationName)
    {
        _doorAnimator.Play(animationName);

        float animationDuration = _doorAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration);

        Debug.Log("Animação " + animationName + " concluída!");
    }

    private void TurnOff()
    {
        if (_overLight != null)
            _overLight.enabled = false;
    }
}
