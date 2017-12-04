using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public AudioSource efxSource;
    public AudioSource musicSource;
    public static AudioManager instance = null;

    public float lowPitchRange = .95f;              
    public float highPitchRange = 1.05f;            

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        musicSource.volume = 0.5f;
        efxSource.volume = 0.8f;
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    public void PlayBackground(AudioClip clip)
    {
        musicSource.clip = clip;

        musicSource.Play();
    }

    public void SetEfxVolume(Slider slider)
    {
        efxSource.volume = slider.value * 0.8f;
    }

    public void SetMasterVolume(Slider slider)
    {
        AudioListener.volume = slider.value;
    }

    public void SetMuxicVolume(Slider slider)
    {
        musicSource.volume = slider.value * 0.5f;
    }
    /*
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        
        efxSource.pitch = randomPitch;
        
        efxSource.clip = clips[randomIndex];
        
        efxSource.Play();
    }
    */
}
