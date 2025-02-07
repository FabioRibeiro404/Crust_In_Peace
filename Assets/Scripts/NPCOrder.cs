using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class NPCOrder : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private List<RecipesData> _allRecipes;
    private RecipesData _choosedOrder;

    public void SelectRandomRecipe()
    {
        if (_allRecipes.Count > 0)
        {
            int randomIndex = Random.Range(0, _allRecipes.Count);
            _choosedOrder = _allRecipes[randomIndex];
            Debug.Log("Receita escolhida: " + _choosedOrder.recipeName);
            ShowSelectedRecipe();
        }
        else
            Debug.LogError("Nenhuma receita disponível!");
    }

    private void ShowSelectedRecipe()
    {
        if (_choosedOrder != null)
        {
            Debug.Log("Receita: " + _choosedOrder.recipeName);
            foreach (var ingredient in _choosedOrder.ingredients)
                Debug.Log("Ingrediente: " + ingredient.ingredients.name + " | Quantidade: " + ingredient.quantity);

            manager.ShowOrder(_choosedOrder);
        }
        else
            Debug.LogError("Nenhuma receita foi selecionada.");
    }

    /*private void CheckOrder()
    {

    }*/
}
