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
            Debug.LogWarning($"Verificando receita: {recipe.name}");
            HashSet<string> ingredientsRecipe = new HashSet<string>();

            foreach (var ingredient in recipe.ingredients)
            {
                if (ingredient?.ingredients == null)
                {
                    Debug.LogError($"Ingrediente nulo encontrado na receita: {recipe.name}");
                    continue;
                }
                ingredientsRecipe.Add(ingredient.ingredients.name);
            }

            if (activeIngredients.SetEquals(ingredientsRecipe))
            {
                _recipe = recipe;
                Debug.Log($"Receita encontrada: {_recipe.name}");
                activeIngredients.Clear();
                return;
            }
        }

        Debug.Log($"Nenhuma receita correspondente encontrada.");
    }
}
