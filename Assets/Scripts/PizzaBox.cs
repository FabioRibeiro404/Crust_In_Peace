using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PizzaBox : MonoBehaviour
{
    private Animator _animator;
    private AttributeRecipe currentRecipe;
    private XRSocketInteractor socketInteractor;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        socketInteractor = GetComponentInChildren<XRSocketInteractor>();
    }

    public void OnPizzaPlaced(SelectEnterEventArgs args)
    {
        GameObject pizza = args.interactableObject.transform.gameObject;

        if (pizza.CompareTag("Pizza"))
        {
            currentRecipe = pizza.GetComponent<AttributeRecipe>();

            Debug.Log("PIZZA DENTRO DA CAIXA É: " + currentRecipe._recipe.name);

            pizza.transform.SetParent(this.transform);

            _animator.SetTrigger("Close");

            Collider collider = pizza.GetComponent<Collider>();
            collider.enabled = false;
        }
    }

    public RecipesData GetRecipe()
    {
        return currentRecipe._recipe;
    }
}
