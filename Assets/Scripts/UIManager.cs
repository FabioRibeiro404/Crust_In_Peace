using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image recipeImage;
    [SerializeField] private Image[] ingredientImages;

    public void ShowOrder(RecipesData selectedRecipe)
    {
        if (selectedRecipe != null)
        {
            recipeImage.sprite = selectedRecipe.recipeIcon;
            recipeImage.enabled = true;

            for (int i = 0; i < ingredientImages.Length; i++)
            {
                if (i < selectedRecipe.ingredients.Count)
                {
                    ingredientImages[i].sprite = selectedRecipe.ingredients[i].ingredients.ingredientIcon;
                    ingredientImages[i].enabled = true;
                }
                else
                    ingredientImages[i].enabled = false;
            }
        }
        else
            Debug.LogError("Receita selecionada não está definida.");
    }
}
