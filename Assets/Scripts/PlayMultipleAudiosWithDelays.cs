// Assets/Scripts/PlayMultipleAudiosWithDelays.cs

using UnityEngine;
using System.Collections;

public class PlayMultipleAudiosWithDelays : MonoBehaviour
{
    // ������ ��� �������� �����������
    public AudioClip[] audioClips;
    // ������ ��� �������� �������� ����� ���������������� ������� ����������
    public float[] delays;

    // ������ �� AudioSource ���������
    private AudioSource audioSource;

    void Start()
    {
        // ���������, ��� ���������� ����������� ������������� ���������� ��������
        if (audioClips.Length != delays.Length)
        {
            Debug.LogError("���������� ����������� ������ ��������� � ����������� ��������.");
            return;
        }

        // �������� ��� ��������� ��������� AudioSource � �������� �������
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ��������� �������� ��� ��������������� ������ � ����������
        StartCoroutine(PlaySoundsWithDelays());
    }

    // ������� ��� ��������������� ������ � ����������
    IEnumerator PlaySoundsWithDelays()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            // ������������� ������� ���������
            audioSource.clip = audioClips[i];
            // ���� �������� ����� ����� ����������������
            yield return new WaitForSeconds(delays[i]);
            // ������������� ����
            audioSource.Play();
            // ����, ���� ������� ��������� �� ���������� ����� ��������� � ����������
            yield return new WaitWhile(() => audioSource.isPlaying);
        }
    }
}
