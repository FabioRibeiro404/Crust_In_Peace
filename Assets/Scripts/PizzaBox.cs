using UnityEngine;

public class PizzaBox : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            animator.SetTrigger("Close");
            Destroy(gameObject);
            Destroy(other.gameObject, 2f);
        }
    }
}
