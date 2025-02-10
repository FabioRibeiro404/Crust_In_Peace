using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    private NPCOrder npcOrder;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        npcOrder = GetComponent<NPCOrder>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (agent != null && animator != null)
            animator.SetBool("isWalking", agent.velocity.magnitude > 0.1f);
    }

    public void GoToBalcony(Transform balcony)
    {
        if (agent == null || balcony == null) return;
        agent.SetDestination(balcony.position);
        npcOrder.SelectRandomRecipe();
    }
}
