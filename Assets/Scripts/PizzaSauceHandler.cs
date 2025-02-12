using UnityEngine;

public class PizzaSauceHandler : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Pizza"))
        {
            foreach (Transform child in other.transform)
            {
                if (gameObject.CompareTag("Sauce Ectoplasm") && child.name.Equals("Sauce Ectoplasm"))
                    child.gameObject.SetActive(true);

            }
        }
    }
}
