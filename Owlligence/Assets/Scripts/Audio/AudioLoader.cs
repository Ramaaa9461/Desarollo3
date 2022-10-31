using UnityEngine;


public static class AudioLoader
{
    const string sfxVolumeValueKey = "SFX Volume";
    const string musicVolumeValueKey = "Music Volume";
    const float defaultSFXVolume = 1.0f;
    const float defaultMusicVolume = 1.0f;

    static float actualSFXVolume;
    static float actualMusicVolume;



    public static float LoadSFXVolumeValue()
    {
        actualSFXVolume = PlayerPrefs.HasKey(sfxVolumeValueKey) ? PlayerPrefs.GetFloat(sfxVolumeValueKey) : defaultSFXVolume;

        return actualSFXVolume;
    }
    public static float LoadMusicVolumeValue()
    {
        actualMusicVolume = PlayerPrefs.HasKey(musicVolumeValueKey) ? PlayerPrefs.GetFloat(musicVolumeValueKey) : defaultMusicVolume;

        return actualMusicVolume;
    }

    public static void SaveSFXVolumeValue(float value)
    {
        PlayerPrefs.SetFloat(sfxVolumeValueKey, value);
    }
    public static void SaveMusicVolumeValue(float value)
    {
        PlayerPrefs.SetFloat(musicVolumeValueKey, value);
    }

    public static float GetActualSFXVolume()
	{
        return actualSFXVolume;
    }
    public static float GetActualMusicVolume()
    {
        return actualMusicVolume;
    }
}
