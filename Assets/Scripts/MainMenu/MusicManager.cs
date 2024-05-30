using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // —сылка на себ€ дл€ реализации синглтона
    public GameObject levelMusicPrefab; // ѕрефаб музыки уровн€
    public GameObject mainMenuMusicPrefab; // ѕрефаб музыки главного меню

    private GameObject levelMusicInstance; // Ёкземпл€р музыки уровн€
    private GameObject mainMenuMusicInstance; // Ёкземпл€р музыки главного меню

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // —охран€ем объект музыкального менеджера при загрузке новых сцен
        }
        else
        {
            Destroy(gameObject); // ”ничтожаем дубликат музыкального менеджера
        }
    }

    public void PlayLevelMusic()
    {
        if (mainMenuMusicInstance != null)
        {
            Destroy(mainMenuMusicInstance); // ”ничтожаем музыку главного меню
        }
        if (levelMusicPrefab != null)
        {
            levelMusicInstance = Instantiate(levelMusicPrefab); // —оздаем экземпл€р музыки уровн€
            DontDestroyOnLoad(levelMusicInstance); // —охран€ем музыку уровн€ при загрузке новых сцен
        }
    }

    public void PlayMainMenuMusic()
    {
        if (levelMusicInstance != null)
        {
            Destroy(levelMusicInstance); // ”ничтожаем музыку уровн€
        }
        if (mainMenuMusicPrefab != null)
        {
            mainMenuMusicInstance = Instantiate(mainMenuMusicPrefab); // —оздаем экземпл€р музыки главного меню
            DontDestroyOnLoad(mainMenuMusicInstance); // —охран€ем музыку главного меню при загрузке новых сцен
        }
    }
}
