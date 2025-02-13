using System.Collections.Generic;
using UnityEngine;

public class AttributeRecipe : MonoBehaviour
{
    [SerializeField] private List<RecipesData> allRecipes;
    public RecipesData _recipe;

    private HashSet<string> activeIngredients = new HashSet<string>();

    public void AddIngredient(string ingredientName)
    {
        if (!activeIngredients.Contains(ingredientName))
        {
            activeIngredients.Add(ingredientName);
            Debug.Log($"Ingrediente adicionado: {ingredientName}");
        }

        if (activeIngredients.Count == 5)
            CheckIngredients();
    }

    private void CheckIngredients()
    {
        foreach (RecipesData recipe in allRecipes)
        {
            Debug.LogWarning(recipe.name);
            HashSet<string> ingredientsRecipe = new HashSet<string>();

            foreach (var ingredient in recipe.ingredients)
            {
                ingredientsRecipe.Add(ingredient.ingredients.name);
            }

            if (activeIngredients.SetEquals(ingredientsRecipe))
            {
                _recipe = recipe;
                Debug.Log($"Receita encontrada: {_recipe.name}");
                activeIngredients.Clear();
                return;
            }
            else
            {
                activeIngredients = new HashSet<string>();
                Debug.Log($"Não encontrou receita");
            }

        }
    }
}
