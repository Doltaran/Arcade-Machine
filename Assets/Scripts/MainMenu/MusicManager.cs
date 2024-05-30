using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // ������ �� ���� ��� ���������� ���������
    public GameObject levelMusicPrefab; // ������ ������ ������
    public GameObject mainMenuMusicPrefab; // ������ ������ �������� ����

    private GameObject levelMusicInstance; // ��������� ������ ������
    private GameObject mainMenuMusicInstance; // ��������� ������ �������� ����

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ������������ ��������� ��� �������� ����� ����
        }
        else
        {
            Destroy(gameObject); // ���������� �������� ������������ ���������
        }
    }

    public void PlayLevelMusic()
    {
        if (mainMenuMusicInstance != null)
        {
            Destroy(mainMenuMusicInstance); // ���������� ������ �������� ����
        }
        if (levelMusicPrefab != null)
        {
            levelMusicInstance = Instantiate(levelMusicPrefab); // ������� ��������� ������ ������
            DontDestroyOnLoad(levelMusicInstance); // ��������� ������ ������ ��� �������� ����� ����
        }
    }

    public void PlayMainMenuMusic()
    {
        if (levelMusicInstance != null)
        {
            Destroy(levelMusicInstance); // ���������� ������ ������
        }
        if (mainMenuMusicPrefab != null)
        {
            mainMenuMusicInstance = Instantiate(mainMenuMusicPrefab); // ������� ��������� ������ �������� ����
            DontDestroyOnLoad(mainMenuMusicInstance); // ��������� ������ �������� ���� ��� �������� ����� ����
        }
    }
}
