using System.Collections;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ButtonOnOff : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    private bool isOn;

    private void Start()
    {
        isOn = false;
    }

    public void ChangeButton()
    {
        isOn = !isOn;

        if (isOn)
        {
            if (_doorAnimator != null)
                StartCoroutine(PlayDoorAnimation("DoorOpen"));
        }
        else
        {
            if (_doorAnimator != null)
                StartCoroutine(PlayDoorAnimation("DoorClose"));
        }

        Debug.Log("Bot�o pressionado! Estado: " + (isOn ? "Ligado" : "Desligado"));
    }

    private IEnumerator PlayDoorAnimation(string animationName)
    {
        _doorAnimator.Play(animationName);

        float animationDuration = _doorAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration);

        Debug.Log("Anima��o " + animationName + " conclu�da!");
    }
}
