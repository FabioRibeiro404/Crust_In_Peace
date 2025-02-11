using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    [SerializeField] private float maxDistance = 5f;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, initialPosition) > maxDistance)
            ResetObject();

        if (transform.position.y <= 0.20f)
            Destroy(gameObject);
    }

    private void ResetObject()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
