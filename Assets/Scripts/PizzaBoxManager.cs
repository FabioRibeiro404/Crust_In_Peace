using UnityEngine;

public class PizzaBoxManager : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    private Animator boxAnimator;
    private Transform spawnPoint;
    private GameObject currentBox;

    private void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }

    private void Update()
    {
        SpawnBox();
    }

    private void SpawnBox()
    {
        if (currentBox == null)
        {
            currentBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
            boxAnimator = currentBox.GetComponent<Animator>();
            boxAnimator.SetTrigger("Open");
        }
    }
}
