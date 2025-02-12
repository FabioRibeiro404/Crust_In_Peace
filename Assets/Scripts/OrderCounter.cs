using UnityEngine;

public class OrderCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PizzaBox")) return;

        PizzaBox pizzaBox = other.GetComponent<PizzaBox>();
        RecipesData pizzaRecipe = pizzaBox.GetRecipe();

        // Tenta encontrar o NPC que está no mesmo trigger
        NPCOrder npcOrder = other.GetComponentInParent<NPCOrder>();
        if (npcOrder == null)
        {
            Debug.Log("Erro: Nenhum NPC encontrado no trigger.");
            return;
        }

        RecipesData npcRecipe = npcOrder.GetChoosedOrder();

        if (pizzaRecipe == null || npcRecipe == null)
        {
            Debug.Log("Erro: Pedido ou pizza inválidos.");
            return;
        }

        if (pizzaRecipe.recipeName == npcRecipe.recipeName)
        {
            FindObjectOfType<NPCSpawner>().ExitNPCMovement();
            Debug.Log("Entrega correta!");
        }
        else
        {
            Debug.Log("Pizza errada!");
        }
    }
}
