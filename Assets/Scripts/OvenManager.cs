using System.Collections;
using UnityEngine;

public class OvenManager : MonoBehaviour
{
    [SerializeField] private ButtonOnOff oven;
    [SerializeField] private Color endColor;
    private float cookingTime = 10f;

    private Renderer materialPizza;
    private Coroutine cookingCoroutine;
    public GameObject cheese;
    public GameObject rawCheese;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pizza") && oven.isOn)
        {
            foreach (Transform child in other.transform)
            {
                if (child.name == "Pizza Dought")
                    materialPizza = child.GetComponent<Renderer>();
                if (child.name == "Cheeses")
                    rawCheese = child.gameObject;
                if (child.name == "Melted Cheese")
                    cheese = child.gameObject;
            }

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

        if (rawCheese != null && rawCheese.activeSelf)
        {
            if (cheese != null)
            {
                cheese.SetActive(true);
                rawCheese.SetActive(false);

                AttributeRecipe attribute = pizza.GetComponent<AttributeRecipe>();
                if (attribute != null)
                {
                    attribute.RemoveIngredient("Cheeses");
                    attribute.AddIngredient("Melted Cheese");
                }
            }
        }

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
