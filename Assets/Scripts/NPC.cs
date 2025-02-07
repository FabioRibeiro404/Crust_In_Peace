using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    private NPCOrder npcOrder;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        npcOrder = GetComponent<NPCOrder>();
    }

    public void GoToBalcony(Transform balcony)
    {
        if (agent == null || balcony == null) return;
        agent.SetDestination(balcony.position);
        npcOrder.SelectRandomRecipe();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger Order")
        {

            Debug.Log("Pode pedir");
            npcOrder.SelectRandomRecipe();
        }
    }*/
}
