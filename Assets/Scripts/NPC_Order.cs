using System.Collections.Generic;
using UnityEngine;

public class NPC_Order : MonoBehaviour
{
    [SerializeField] private List<RecipesData> _allRecipes;
    private RecipesData _choosedOrder;

    private void Start()
    {
        SelectRandomRecipe(); 
        ShowSelectedRecipe();
    }

    public void SelectRandomRecipe()
    {
        if (_allRecipes.Count > 0)
        {
            int randomIndex = Random.Range(0, _allRecipes.Count);
            _choosedOrder = _allRecipes[randomIndex];
            Debug.Log("Receita escolhida: " + _choosedOrder.recipeName);
        }
        else
            Debug.LogError("Nenhuma receita disponível!");
    }

    public void ShowSelectedRecipe()
    {
        if (_choosedOrder != null)
        {
            Debug.Log("Receita: " + _choosedOrder.recipeName);
            foreach (var ingredient in _choosedOrder.ingredients)
                Debug.Log("Ingrediente: " + ingredient.ingredients.name + " | Quantidade: " + ingredient.quantity);
        }
        else
            Debug.LogError("Nenhuma receita foi selecionada.");
    }
}
