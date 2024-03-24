using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentLevel = 0; // ������� �������

    void Awake()
    {
        // ����������, ��� � ��� ���� ������ ���� ��������� GameManager � �����
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

    // ����� ��� ��������� �������� ������
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
}
