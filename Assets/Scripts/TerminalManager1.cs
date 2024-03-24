using UnityEngine;
using UnityEngine.UI;

public class TerminalManager1 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public CanvasManager canvasManager;
    
    public GameObject objectWithCollider;
    private Collider2D colliderToDisable;
    private LevelData levelData; // ������ �� ��������� LevelData

    private void Start()
    {
        colliderToDisable = objectWithCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);

        // �������� ������ � ���������� LevelData �� �����
        levelData = FindObjectOfType<LevelData>();
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        string correctPassword = GetCorrectPassword(); // �������� ���������� ����� �� LevelData

        if (inputPassword == correctPassword)
        {
            canvasManager.HideTerminalInterface();
            Debug.Log("������ ��������!");

            if (colliderToDisable != null)
            {
                colliderToDisable.enabled = false;
            }
        }
        else
        {
            
            Debug.Log("�������� ������!");
            passwordInput.text = "";
        }
    }

    // ����� ��� ��������� ����������� ������ �� LevelData
    private string GetCorrectPassword()
    {
        if (levelData != null)
        {
            // ��������� ������� ������� � �������� ��������������� ����� �� LevelData
            return levelData.GetCurrentNumberVariation();
        }
        else
        {
            Debug.LogError("LevelData �� ������ �� �����!");
            return ""; // ���������� ������ ������ � ������ ������
        }
    }
}
