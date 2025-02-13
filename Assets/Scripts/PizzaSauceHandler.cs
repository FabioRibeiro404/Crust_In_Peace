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

                if (gameObject.CompareTag("Sauce Swap Mud") && child.name.Equals("Sauce Swap Mud"))
                    child.gameObject.SetActive(true);

                if (gameObject.CompareTag("Sauce Hell blood") && child.name.Equals("Sauce Blood from Hell"))
                    child.gameObject.SetActive(true);

                if (gameObject.CompareTag("Sauce Blood") && child.name.Equals("Sauce Blood"))
                    child.gameObject.SetActive(true);
            }

        }
    }
}
