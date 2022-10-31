using UnityEngine;
using UnityEngine.UI;


public class UIInteractor : MonoBehaviour
{
	[SerializeField] Slider sfxSlider;
	[SerializeField] Slider musicSlider;


	void Start()
	{
		sfxSlider.value = AudioController.GetActualSFXVolume();
		musicSlider.value = AudioController.GetActualMusicVolume();
	}
}
