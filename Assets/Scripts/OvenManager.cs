using System.Collections;
using UnityEngine;

public class OvenManager : MonoBehaviour
{
    [SerializeField] private ButtonOnOff oven;
    [SerializeField] private Color endColor;
    private float cookingTime = 10f;

    private Renderer materialPizza;
    private Coroutine cookingCoroutine;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pizza") && oven.isOn)
        {
            materialPizza = other.GetComponent<Renderer>();

            if (materialPizza != null && materialPizza.material.color != endColor)
            {
                if (cookingCoroutine == null)
                    cookingCoroutine = StartCoroutine(Cooking(other.gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pizza") && cookingCoroutine != null)
        {
            StopCoroutine(cookingCoroutine);
            cookingCoroutine = null;
        }
    }

    private IEnumerator Cooking(GameObject pizza)
    {
        if (materialPizza == null) yield break;

        float elapsedTime = 0f;
        Color startColor = materialPizza.material.color;

        while (elapsedTime < cookingTime)
        {
            if (!oven.isOn)
            {
                cookingCoroutine = null;
                yield break;
            }

            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / cookingTime;
            materialPizza.material.color = Color.Lerp(startColor, endColor, progress);
            yield return null;
        }

        Debug.Log("COOK");
        materialPizza.material.color = endColor;
        oven.isOn = false;
        cookingCoroutine = null;
        oven._overLight.enabled = false;
    }
}
