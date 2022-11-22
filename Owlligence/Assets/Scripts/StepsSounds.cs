using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSounds : MonoBehaviour
{

    [SerializeField] List<AudioClip> stepsInWater;
    [SerializeField] List<AudioClip> stepsOnLand;
    [SerializeField] float secondsBetweenSteps = 0.4f;
    AudioSource audioSource;
    Coroutine playStepSound;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    public void randomSoundStepOnLand()
    {
        if (playStepSound == null)
        {
            playStepSound = StartCoroutine(PlayStepSound(true));
        }
    }
    public void randomSoundStepInWater()
    {
        if (playStepSound == null)
        {
            playStepSound = StartCoroutine(PlayStepSound(false));
        }
    }

    IEnumerator PlayStepSound(bool onLand)
    {
        if (onLand)
        {
            audioSource.PlayOneShot(stepsOnLand[Random.Range(0, stepsOnLand.Count)]);   
        }
        else
        {
            audioSource.PlayOneShot(stepsInWater[Random.Range(0, stepsInWater.Count)]); 
        }


        yield return new WaitForSeconds(secondsBetweenSteps);
        playStepSound = null;
    }
}
