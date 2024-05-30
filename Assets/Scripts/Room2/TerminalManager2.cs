using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerminalManager2 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public string correctPasswordRobot = "1101"; // ������ ��� ���������� ������
    public string correctPasswordWall = "0101"; // ������ ��� ���������� �����
    public CanvasManager canvasManager;
    public GameController gameController; // ��������� GameController
    public GameObject objectWithRobotCollider; // ������ �� ������ � ����������� ������
    public GameObject objectWithWallCollider; // ������ �� ������ � ����������� �����
    public Animator robotAnimator; // ������ �� Animator ������
    public Animator wallAnimator; // ������ �� Animator �����
    public float robotPowerOffDelay = 1f; // �������� ����� ����������� ������
    public float wallPowerOffDelay = 1.2f; // �������� ����� ����������� �����
    public Animator RedAnimator; // ������ �� Animator ������
    public Animator YellowAnimator; // ������ �� Animator �����
    private Collider2D robotColliderToDisable;
    private Collider2D wallColliderToDisable;
    private bool wallColliderDisabled = false; // ���� ��� ������������ ��������� ���������� �����
    public AudioClip correctPasswordAudio; // ��������� ��� ����������� ������
    public AudioClip incorrectPasswordAudio;
    private AudioSource audioSource;

    private void Start()
    {
        robotColliderToDisable = objectWithRobotCollider.GetComponent<Collider2D>();
        wallColliderToDisable = objectWithWallCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);
        audioSource = gameObject.AddComponent<AudioSource>();

        // ������ �������� ��� ��������������� ���������� ���������� ����� ����� �������� �����
        StartCoroutine(AutoDisableWallCollider(90f));
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        if (inputPassword == correctPasswordRobot)
        {
            audioSource.PlayOneShot(correctPasswordAudio);
            canvasManager.HideTerminalInterface();
            Debug.Log("������ ��������!");
            // ��������� ��������� ������
            if (robotColliderToDisable != null)
            {
                robotColliderToDisable.enabled = false;
            }
            // ������������� �������� ������
            gameController.SetShootingAllowed(false);

            // ��������� ������������������ �������� ��� ������
            StartCoroutine(PlayRobotAnimationSequence());
        }
        else if (inputPassword == correctPasswordWall)
        {    audioSource.PlayOneShot(correctPasswordAudio);
            canvasManager.HideTerminalInterface();
            Debug.Log("������ ��������!");

            // ��������� ������������������ �������� ��� �����
            StartCoroutine(PlayWallAnimationSequence());
        }
        else
        {
            audioSource.PlayOneShot(incorrectPasswordAudio);
            Debug.Log("�������� ������!");
            passwordInput.text = ""; // ������� ���� �����
        }

      

    }

    private IEnumerator PlayRobotAnimationSequence()
    {
        RedAnimator.SetTrigger("RedIntered");
        yield return new WaitForSeconds(robotPowerOffDelay);
        robotAnimator.SetTrigger("PasswordEntered");

        // ����� �� ������ �������� �������������� �������� ����� �������� ���������� ������
    }

    private IEnumerator PlayWallAnimationSequence()
    {
        YellowAnimator.SetTrigger("WallDisabled");
        yield return new WaitForSeconds(wallPowerOffDelay);
        wallAnimator.SetTrigger("WallDisable");

        // �������� ���������� ��������
        float animationLength = wallAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        // ��������� ��������� �����, ���� �� ��� �� ��� ��������
        DisableWallCollider();
    }

    private IEnumerator AutoDisableWallCollider(float delay)
    {
        // ���� �������� �����
        yield return new WaitForSeconds(delay);

        // ��������� �������� ���������� �����
        YellowAnimator.SetTrigger("WallDisabled");
        yield return new WaitForSeconds(wallPowerOffDelay);
        wallAnimator.SetTrigger("WallDisable");

        // �������� ���������� ��������
        float animationLength = wallAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        // ��������� ��������� �����, ���� �� ��� �� ��� ��������
        DisableWallCollider();
    }

    private void DisableWallCollider()
    {
        if (!wallColliderDisabled && wallColliderToDisable != null)
        {
            wallColliderToDisable.enabled = false;
            wallColliderDisabled = true;
            Debug.Log("Wall collider disabled.");
        }
        else if (wallColliderToDisable == null)
        {
            Debug.LogError("Wall collider is not assigned!");
        }
    }
}
