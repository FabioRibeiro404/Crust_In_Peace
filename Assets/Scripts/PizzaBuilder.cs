using UnityEngine;

public class PizzaBuilder : MonoBehaviour
{
    private AttributeRecipe attribute;

    private void Start()
    {
        attribute = GetComponent<AttributeRecipe>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredients"))
        {
            foreach (Transform child in transform)
            {
                if (child.name.Equals("Fingers") && other.gameObject.name.Contains("Fingers"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Eyes") && other.gameObject.name.Contains("Eyes"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Cheeses") && other.gameObject.name.Contains("Cheeses"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Pepperonis") && other.gameObject.name.Contains("Pepperonis"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Bugs") && other.gameObject.name.Contains("Bugs"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Dirt") && other.gameObject.name.Contains("Dirt"))
                    child.gameObject.SetActive(true);

                if (child.name.Equals("Brains") && other.gameObject.name.Contains("Brains"))
                    child.gameObject.SetActive(true);

                Destroy(other.gameObject);

                if (child.CompareTag("Ingredients") && child.gameObject.activeSelf)
                    attribute.AddIngredient(child.name);
            }
        }
    }
}
