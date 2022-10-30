using System.Collections.Generic;

using UnityEngine;


public class AudioController : MonoBehaviour
{
	[SerializeField] List<AudioSource> sfxSources = null;
	[SerializeField] List<AudioSource> musicSources = null;

	[SerializeField] float temporalSFXVolume = 0.0f;
	[SerializeField] float temporalMusicVolume = 0.0f;



	void Awake()
	{
		temporalSFXVolume = AudioLoader.LoadSFXVolumeValue();
		temporalMusicVolume = AudioLoader.LoadMusicVolumeValue();
	}



	public static float GetActualSFXVolume()
	{
		return AudioLoader.GetActualSFXVolume();
	}
	public static float GetActualMusicVolume()
	{
		return AudioLoader.GetActualMusicVolume();
	}


	public void SetActualSFXVolume()
	{
		AudioLoader.SaveSFXVolumeValue(temporalSFXVolume);
	}
	public void SetActualMusicVolume()
	{
		AudioLoader.SaveMusicVolumeValue(temporalMusicVolume);
	}

	public void LoadAudioSources()
	{
		AudioSource[] localAudioSourceArray = FindObjectsOfType<AudioSource>();


		for (int i = 0; i < localAudioSourceArray.Length; i++)
		{
			if (localAudioSourceArray[i].loop)
			{
				musicSources.Add(localAudioSourceArray[i]);
			}
			else
			{
				sfxSources.Add(localAudioSourceArray[i]);
			}
		}
	}

	public void SaveTemporalSFXVolume(float value)
	{
		temporalSFXVolume = value;
	}
	public void SaveTemporalMusicVolume(float value)
	{
		temporalMusicVolume = value;
	}
}
