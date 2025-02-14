using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefabs;
    [SerializeField] private Transform balcony;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxNPCs;

    private Queue<NPC> npcQueue = new Queue<NPC>();
    public NPC currentNPC;
    private GameObject npcObj;
    private int activeNPCCount = 0;
    public int npcRemoved;

    private void Start()
    {
        StartCoroutine(SpawnNPCs());
        npcRemoved = maxNPCs;
    }

    private IEnumerator SpawnNPCs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (activeNPCCount < maxNPCs)
            {
                SpawnRandomNPC();
            }
        }
    }

    private void SpawnRandomNPC()
    {
        int randomIndex = Random.Range(0, npcPrefabs.Length);
        npcObj = Instantiate(npcPrefabs[randomIndex], spawnPoint.position, Quaternion.Euler(0, 180, 0));
        NPC newNPC = npcObj.GetComponent<NPC>();

        npcQueue.Enqueue(newNPC);
        activeNPCCount++;

        if (currentNPC == null)
        {
            MoveNextNPC();
        }
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
        {
            currentNPC.GoToBalcony(balcony);
        }
    }

    public void ExitNPCMovement()
    {
        if (currentNPC != null)
        {
            currentNPC.GoExit(exitPoint);
            StartCoroutine(DestroyNPC(currentNPC.gameObject));
        }

        currentNPC = null;
        MoveNextNPC();
    }

    private IEnumerator DestroyNPC(GameObject npcObj)
    {
        yield return new WaitForSeconds(2f);
        if (npcObj != null)
        {

            Destroy(npcObj);
            npcRemoved--;
        }

    }
}
