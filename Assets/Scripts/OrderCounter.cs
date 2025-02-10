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
                // Aqui voc� pode adicionar l�gica extra, como recompensas ou remo��o do NPC
            }
            else
            {
                Debug.Log("O pedido n�o corresponde ao solicitado.");
            }
        }
    }
}
