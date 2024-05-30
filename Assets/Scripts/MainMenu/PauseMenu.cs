using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Панель главного меню
    public bool isPaused = false;
    private AudioSource[] allAudioSources;

    void Start()
    {
        // Получаем все аудио источники в сцене
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

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
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Скрыть меню
        Time.timeScale = 1f; // Возобновить игру
        isPaused = false;
        // Возобновляем все аудио источники
        foreach (AudioSource audio in allAudioSources)
        {
            audio.UnPause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Показать меню
        Time.timeScale = 0f; // Остановить игру
        isPaused = true;
        // Приостанавливаем все аудио источники
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Pause();
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Установить нормальную скорость перед загрузкой меню
        // Останавливаем все аудио источники перед загрузкой главного меню
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Stop();
        }
        SceneManager.LoadScene("MainMenu"); // Загрузить главное меню
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Выйти из игры
    }
}
