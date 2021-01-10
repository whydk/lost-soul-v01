using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                float music;
                bool musicResult = musicMixer.GetFloat("MusicVolume", out music);
                if (musicResult)
                {
                    musicSlider.value = music;
                }
                float sfx;
                bool sfxResult = sfxMixer.GetFloat("SFXVolume", out sfx);
                if (sfxResult)
                {
                    sfxSlider.value = sfx;
                }
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void LoadMenu()
    {
        Initiate.Fade("Menu", Color.black, 1f);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        Initiate.Fade("LoadingScreen", Color.black, 1f);
        Time.timeScale = 1f;
    }
    public void SfxVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", volume);

    }
    public void MusicVolume(float volume)
    {
        musicMixer.SetFloat("MusicVolume", volume);

    }
}
