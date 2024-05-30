using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndScreen : MonoBehaviour
{
    public GameObject endScreenPanel; // ������ ��� Image ��� ������� ����
    public Text endScreenText;
    public float displayDuration = 3f; // ������������ ����������� ��������

    private void Start()
    {
        endScreenPanel.SetActive(false); // ������ ������ ��������
        endScreenText.enabled = false; // ������ �����
    }

    public void ShowEndScreen()
    {
        endScreenPanel.SetActive(true); // �������� ������ ��������
        endScreenText.enabled = true; // �������� �����
        Invoke("LoadMainMenu", displayDuration);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // �������� "MainMenu" �� ��� ����� ����� �������� ����
    }
}
