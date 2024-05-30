using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VolumeSettings : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;


    void Start()
    {


        // Применяем текущую громкость
        audioSrc = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (audioSrc != null)
        {
            audioSrc.volume = musicVolume;
        }
    }

    public void SetVolume(float volume)
    {

        musicVolume = volume;
    }
}
