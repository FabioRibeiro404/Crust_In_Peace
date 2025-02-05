using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cooking/Recipe", menuName = "Cooking/New Recipe")]
public class RecipesData : ScriptableObject
{
    [System.Serializable]
    public class IngredientAmount
    {
        public IngredientsData ingredients;
        public int quantity; 
    }

    public string recipeName;
    public List<IngredientAmount> ingredients;
}
