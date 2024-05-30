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
    public Animator animator;
    public AudioClip correctPasswordAudio; // ��������� ��� ����������� ������
    public AudioClip incorrectPasswordAudio; // ��������� ��� ������������� ������
    private AudioSource audioSource;

    private void Start()
    {
        colliderToDisable = objectWithCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);

        // �������� ������ � ���������� LevelData �� �����
        levelData = FindObjectOfType<LevelData>();

        // ������������� AudioSource ����������
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        string correctPassword = GetCorrectPassword(); // �������� ���������� ����� �� LevelData

        if (inputPassword == correctPassword)
        {
            canvasManager.HideTerminalInterface();
            Debug.Log("������ ��������!");
            animator.SetTrigger("PasswordInput");
            animator.Play("PasswordInput");
            if (colliderToDisable != null)
            {
                colliderToDisable.enabled = false;
            }

            // ������������� ����� ��� ����������� ������
            if (correctPasswordAudio != null)
            {
                audioSource.PlayOneShot(correctPasswordAudio);
            }
        }
        else
        {
            Debug.Log("�������� ������!");
            passwordInput.text = "";

            // ������������� ����� ��� ������������� ������
            if (incorrectPasswordAudio != null)
            {
                audioSource.PlayOneShot(incorrectPasswordAudio);
            }
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
