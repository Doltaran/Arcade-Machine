// Assets/Scripts/PlayMultipleAudiosWithDelays.cs

using UnityEngine;
using System.Collections;

public class PlayMultipleAudiosWithDelays : MonoBehaviour
{
    // Массив для хранения аудиоклипов
    public AudioClip[] audioClips;
    // Массив для хранения задержек перед воспроизведением каждого аудиоклипа
    public float[] delays;

    // Ссылка на AudioSource компонент
    private AudioSource audioSource;

    void Start()
    {
        // Проверяем, что количество аудиоклипов соответствует количеству задержек
        if (audioClips.Length != delays.Length)
        {
            Debug.LogError("Количество аудиоклипов должно совпадать с количеством задержек.");
            return;
        }

        // Получаем или добавляем компонент AudioSource к текущему объекту
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Запускаем корутину для воспроизведения звуков с задержками
        StartCoroutine(PlaySoundsWithDelays());
    }

    // Корутин для воспроизведения звуков с задержками
    IEnumerator PlaySoundsWithDelays()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            // Устанавливаем текущий аудиоклип
            audioSource.clip = audioClips[i];
            // Ждем заданное время перед воспроизведением
            yield return new WaitForSeconds(delays[i]);
            // Воспроизводим звук
            audioSource.Play();
            // Ждем, пока текущий аудиоклип не закончится перед переходом к следующему
            yield return new WaitWhile(() => audioSource.isPlaying);
        }
    }
}
