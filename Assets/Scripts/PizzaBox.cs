using UnityEngine;

public class PizzaBox : MonoBehaviour
{
    private Animator animator;
    private RecipesData currentRecipe;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            currentRecipe = other.GetComponent<RecipesData>();
            animator.SetTrigger("Close");
            Destroy(gameObject);
            Destroy(other.gameObject, 2f);
        }
    }


    public RecipesData GetRecipe()
    {
        return currentRecipe;
    }
}
