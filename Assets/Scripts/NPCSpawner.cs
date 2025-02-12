using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefabs;
    [SerializeField] private Transform balcony;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxNPCs = 5;

    private Queue<NPC> npcQueue = new Queue<NPC>();
    public NPC currentNPC;
    private GameObject npcObj;

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
        npcObj = Instantiate(npcPrefabs[randomIndex], spawnPoint.position, Quaternion.Euler(0, 180, 0));
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


    public void ExitNPCMovement()
    {
        if (currentNPC != null)
            currentNPC.GoExit(exitPoint);

        currentNPC = null;
    }


}
