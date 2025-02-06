using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class NPC : MonoBehaviour
{
    [SerializeField] private Transform balcony;
    private NPC_Order npcOrder;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        npcOrder = GetComponent<NPC_Order>();
        agent.SetDestination(balcony.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger Order")
            npcOrder.SelectRandomRecipe();
    }
    private void UpdateDestination()
    {
        agent.SetDestination(balcony.position);
    }
}
