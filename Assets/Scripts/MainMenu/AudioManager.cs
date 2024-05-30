using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    void Start()
    {
        // �������� ��� ����� ��������� � �����
        allAudioSources = FindObjectsOfType<AudioSource>();
        // ��������� ��� ����� ���������
        foreach (AudioSource audio in allAudioSources)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }
}
