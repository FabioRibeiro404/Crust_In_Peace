using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttributeRecipe : MonoBehaviour
{
    [SerializeField] private List<RecipesData> allRecipes;
    public RecipesData _recipe;

    public void CheckIngredients()
    {
        List<string> activeIngredients = new List<string>();

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                activeIngredients.Add(child.gameObject.name);
            }
        }

        _recipe = FindMatchingRecipe(activeIngredients);

        if (_recipe != null)
        {
            Debug.Log("Receita Identificada: " + _recipe.recipeName);
        }
        else
        {
            Debug.Log("Nenhuma receita correspondente encontrada.");
        }
    }

    private RecipesData FindMatchingRecipe(List<string> activeIngredients)
    {
        foreach (var recipe in allRecipes)
        {
            List<string> recipeIngredients = new List<string>();

            foreach (var ingredient in recipe.ingredients)
            {
                recipeIngredients.Add(ingredient.ingredients.name);
            }

            if (activeIngredients.Count == recipeIngredients.Count && !recipeIngredients.Except(activeIngredients).Any())
            {
                return recipe;
            }
        }
        return null;
    }
}
