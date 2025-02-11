using UnityEngine;

public class PizzaSauceHandler : MonoBehaviour
{
    [SerializeField] private GameObject ectoplasmPizza;
    [SerializeField] private GameObject bloodPizza;
    [SerializeField] private GameObject hellPizza;
    [SerializeField] private GameObject swampPizza;

    void OnParticleCollision(GameObject other)
    {
        GameObject newPizzaPrefab = null;

        if (other.CompareTag("Pizza"))
        {
            if (gameObject.CompareTag("Sauce Ectoplasm"))
                newPizzaPrefab = ectoplasmPizza;
        }

        if (newPizzaPrefab != null)
        {
            GameObject newPizza = Instantiate(newPizzaPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
