using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // ������ �������� ����
    public bool isPaused = false;
    private AudioSource[] allAudioSources;

    void Start()
    {
        // �������� ��� ����� ��������� � �����
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
        pauseMenuUI.SetActive(false); // ������ ����
        Time.timeScale = 1f; // ����������� ����
        isPaused = false;
        // ������������ ��� ����� ���������
        foreach (AudioSource audio in allAudioSources)
        {
            audio.UnPause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // �������� ����
        Time.timeScale = 0f; // ���������� ����
        isPaused = true;
        // ���������������� ��� ����� ���������
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Pause();
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // ���������� ���������� �������� ����� ��������� ����
        // ������������� ��� ����� ��������� ����� ��������� �������� ����
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Stop();
        }
        SceneManager.LoadScene("MainMenu"); // ��������� ������� ����
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // ����� �� ����
    }
}
