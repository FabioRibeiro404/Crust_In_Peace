using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    private NPCOrder npcOrder;
    private Animator animator;
    private AudioSource audioSource;

    [Header("Configuração de Sons")]
    public List<AudioClip> sounds;
    public float minInterval = 2f; 
    public float maxInterval = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        npcOrder = GetComponent<NPCOrder>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        StartCoroutine(PlayRandomSound());
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

    private IEnumerator PlayRandomSound()
    {
        while (true)
        {
            if (sounds.Count > 0 && audioSource != null)
            {
                AudioClip clip = sounds[Random.Range(0, sounds.Count)];
                audioSource.clip = clip;
                audioSource.Play();
            }

            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
