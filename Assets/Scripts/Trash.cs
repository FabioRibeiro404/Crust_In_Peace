using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    private void OnTriggerEnter(Collider other)
    {
        _particles.Play();
        Destroy(other.gameObject);
    }
}
