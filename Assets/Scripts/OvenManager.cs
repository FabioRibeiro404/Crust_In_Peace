using System.Collections;
using UnityEngine;

public class OvenManager : MonoBehaviour
{
    [SerializeField] private ButtonOnOff oven;
    [SerializeField] private Color endColor;
    private float cookingTime = 10f;

    private Renderer materialPizza;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza") && oven.isOn)
        {
            materialPizza = other.GetComponent<Renderer>();

            if (materialPizza != null && materialPizza.material.color != endColor)
                StartCoroutine(Cooking(other.gameObject));
        }
    }

    private IEnumerator Cooking(GameObject pizza)
    {
        if (materialPizza == null) yield break;

        float elapsedTime = 0f;
        Color startColor = materialPizza.material.color;

        while (elapsedTime < cookingTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / cookingTime;
            materialPizza.material.color = Color.Lerp(startColor, endColor, progress);
            yield return null;
        }

        Debug.Log("COOK");
        materialPizza.material.color = endColor;
        oven.isOn = false;
    }
}
