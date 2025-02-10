using UnityEngine;

public class OrderCounter : MonoBehaviour
{
    [SerializeField] private NPCOrder npcOrder;

    private void OnTriggerEnter(Collider other)
    {
        PizzaBox orderHolder = other.GetComponent<PizzaBox>();

        if (orderHolder != null)
        {
            bool isCorrect = npcOrder.CheckOrder(orderHolder.GetRecipe());

            if (isCorrect)
            {
                Debug.Log("Entrega confirmada!");
                // Aqui você pode adicionar lógica extra, como recompensas ou remoção do NPC
            }
            else
            {
                Debug.Log("O pedido não corresponde ao solicitado.");
            }
        }
    }
}
