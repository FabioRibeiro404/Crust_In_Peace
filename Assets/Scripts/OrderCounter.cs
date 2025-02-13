using UnityEngine;

public class OrderCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PizzaBox"))
        {
            PizzaBox pizzaBox = other.GetComponent<PizzaBox>();
            RecipesData pizzaRecipe = pizzaBox.GetRecipe();

            NPCOrder npcOrder = other.GetComponentInParent<NPCOrder>();
            if (npcOrder == null)
                npcOrder = FindNPCInTrigger();

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

                foreach (Transform child in other.transform)
                {
                    if (child.name.Contains("Pizza Base"))
                        Destroy(child.gameObject);
                }
                Destroy(other.gameObject);
            }
            else
                Debug.Log("Pizza errada!");
        }
    }

    private NPCOrder FindNPCInTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("NPC"))
            {
                NPCOrder npcOrder = collider.GetComponent<NPCOrder>();
                if (npcOrder != null)
                    return npcOrder;
            }
        }

        return null;
    }
}
