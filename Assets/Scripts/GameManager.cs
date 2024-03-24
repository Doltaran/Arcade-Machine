using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentLevel = 0; // Текущий уровень

    void Awake()
    {
        // Убеждаемся, что у нас есть только один экземпляр GameManager в сцене
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Метод для получения текущего уровня
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
}
