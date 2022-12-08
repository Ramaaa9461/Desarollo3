using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIntroTransition : MonoBehaviour
{
    [SerializeField] AudioClip Loop;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = Loop;
            audioSource.Play();
        }
    }
}
