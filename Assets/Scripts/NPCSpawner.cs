using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefabs;
    [SerializeField] private Transform balcony;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxNPCs = 5;

    private Queue<NPC> npcQueue = new Queue<NPC>();
    private NPC currentNPC;

    private void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    private IEnumerator SpawnNPCs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (npcQueue.Count < maxNPCs)
                SpawnRandomNPC();
        }
    }

    private void SpawnRandomNPC()
    {
        int randomIndex = Random.Range(0, npcPrefabs.Length);
        GameObject npcObj = Instantiate(npcPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        NPC newNPC = npcObj.GetComponent<NPC>();

        npcQueue.Enqueue(newNPC);

        if (currentNPC == null)
            MoveNextNPC();
    }


    public void MoveNextNPC()
    {
        if (npcQueue.Count > 0)
        {
            currentNPC = npcQueue.Dequeue();
            Invoke(nameof(StartNPCMovement), 0.1f);
        }
    }

    private void StartNPCMovement()
    {
        if (currentNPC != null)
            currentNPC.GoToBalcony(balcony);
    }

    public void OnNPCFinished()
    {
        currentNPC = null;
        MoveNextNPC();
    }
}
