using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public AudioMixer master;
    public AudioMixer sfx;
    
    public Slider sfxSlider;
    public Slider masterSlider;
    
    void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 0);
    }
    public void SetVolumeMaster(float volume)
    {
        master.SetFloat("masterVolume", volume);
    }
    
    public void SetVolumeSfx(float volume)
    {
        sfx.SetFloat("sfxVolume", volume);
    }
    
    private void OnDisable()
    {
        float sfxVolume = 0;
        float masterVolume = 0;
    
        master.GetFloat("masterVolume", out masterVolume);
        sfx.GetFloat("sfxVolume", out sfxVolume);
    
        PlayerPrefs.SetFloat("masterVolume",masterVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
