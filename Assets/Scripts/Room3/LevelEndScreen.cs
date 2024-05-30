using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndScreen : MonoBehaviour
{
    public GameObject endScreenPanel; // Панель или Image для темного фона
    public Text endScreenText;
    public float displayDuration = 3f; // Длительность отображения заставки

    private void Start()
    {
        endScreenPanel.SetActive(false); // Скрыть панель заставки
        endScreenText.enabled = false; // Скрыть текст
    }

    public void ShowEndScreen()
    {
        endScreenPanel.SetActive(true); // Показать панель заставки
        endScreenText.enabled = true; // Показать текст
        Invoke("LoadMainMenu", displayDuration);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Замените "MainMenu" на имя вашей сцены главного меню
    }
}
