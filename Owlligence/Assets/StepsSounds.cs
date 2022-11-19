using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSounds : MonoBehaviour
{

    [SerializeField] List<AudioClip> stepsInWater;
    [SerializeField] List<AudioClip> stepsOnLand;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    public void randomSoundStepOnLand()
    {
       // audioSource.PlayOneShot(stepsOnLand[Random.Range(0, stepsOnLand.Count)]); //Suenan demasiados pasos a la vez, no se entiende
        
        //audioSource.clip = stepsOnLand[Random.Range(0, stepsOnLand.Count)]; //Se cambian tan rapido que no llega a sonar
        //audioSource.Play();
    }
    public void randomSoundStepInWater()
    {
        audioSource.clip = stepsInWater[Random.Range(0, stepsInWater.Count)];
        audioSource.Play();
    }
}
