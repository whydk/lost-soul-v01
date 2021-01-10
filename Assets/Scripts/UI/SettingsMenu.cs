using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    /*    public static float musicVolume;
        public static float sfxVolume;*/
    public AudioMixer musicVolume;
    public AudioMixer sfxVolume;
    public Slider musicSlider;
    public Slider sfxSlider;
    private void Update()
    {
        float music;
        bool musicResult = musicVolume.GetFloat("MusicVolume", out music);
        if (musicResult)
        {
            musicSlider.value = music;
        }
        float sfx;
        bool sfxResult = sfxVolume.GetFloat("SFXVolume", out sfx);
        if (sfxResult)
        {
            sfxSlider.value = sfx;
        }
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxVolume.SetFloat("SFXVolume", volume);
    }
}
