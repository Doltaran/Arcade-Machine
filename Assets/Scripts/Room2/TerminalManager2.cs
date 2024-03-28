using UnityEngine;
using UnityEngine.UI;

public class TerminalManager2 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public string correctPassword = "1101"; // ������ ��� ��������
    public CanvasManager canvasManager;
    public GameController gameController; // ��������� GameController
    public GameObject objectWithCollider; // ������ �� ������ � �����������
    private Collider2D colliderToDisable;

    private void Start()
    {
        colliderToDisable = objectWithCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        if (inputPassword == correctPassword)
        {
            canvasManager.HideTerminalInterface();
            Debug.Log("������ ��������!");
            // �������� ����� ������ ��� ���������� ������ ��� ���-�� ��������
            if (colliderToDisable != null)
            {
                colliderToDisable.enabled = false;
                // Collider ������ ��������
            }

        }
        else
        {   // ������������� ���� � GameController, ��� �� ���������� ������ ������
            gameController.SetCorrectPasswordEntered(true);
            // �������� ����� ��� ���������� ��������� � GameController
            gameController.ControlProjectiles();
            Debug.Log("�������� ������!"); // ������� ��������� �� ������ � �������
            passwordInput.text = ""; // ������� ���� �����
        }
    }
}