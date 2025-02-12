using UnityEngine;

public class PizzaBuilder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredients"))
        {
            foreach (Transform child in transform)
            {
                if (child.name.Equals("Fingers") && other.gameObject.name.Contains("Fingers"))
                    child.gameObject.SetActive(true);

                Destroy(other.gameObject);
            }
        }
    }
}
