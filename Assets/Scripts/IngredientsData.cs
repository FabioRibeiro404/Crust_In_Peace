using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Cooking/New Ingredient")]
public class IngredientsData : ScriptableObject
{
    public Sprite ingredientIcon;
    public string ingredientName;
}
