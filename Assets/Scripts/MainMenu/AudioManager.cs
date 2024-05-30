using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    void Start()
    {
        // Получаем все аудио источники в сцене
        allAudioSources = FindObjectsOfType<AudioSource>();
        // Запускаем все аудио источники
        foreach (AudioSource audio in allAudioSources)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }
}
