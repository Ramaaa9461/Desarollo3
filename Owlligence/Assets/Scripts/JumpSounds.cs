using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSounds : MonoBehaviour
{
    [SerializeField] List<AudioClip> jumpInWater;
    [SerializeField] List<AudioClip> jumpOnLand;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    public void randomSoundJumpOnLand()
    {
        audioSource.PlayOneShot(jumpOnLand[Random.Range(0, jumpOnLand.Count)]);
    }

    public void randomSoundJumpInWater()
    {
        audioSource.PlayOneShot(jumpInWater[Random.Range(0, jumpInWater.Count)]);
    }
}
