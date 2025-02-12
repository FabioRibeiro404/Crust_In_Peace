using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trash : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private AudioClip sound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _particles.Play();
        PlaySound();
        Destroy(other.gameObject);
    }

    private void PlaySound()
    {
        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}

