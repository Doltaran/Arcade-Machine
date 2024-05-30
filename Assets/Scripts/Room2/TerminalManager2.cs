using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerminalManager2 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public string correctPasswordRobot = "1101"; // Пароль для отключения робота
    public string correctPasswordWall = "0101"; // Пароль для отключения стены
    public CanvasManager canvasManager;
    public GameController gameController; // Добавляем GameController
    public GameObject objectWithRobotCollider; // Ссылка на объект с коллайдером робота
    public GameObject objectWithWallCollider; // Ссылка на объект с коллайдером стены
    public Animator robotAnimator; // Ссылка на Animator робота
    public Animator wallAnimator; // Ссылка на Animator стены
    public float robotPowerOffDelay = 1f; // Задержка перед отключением робота
    public float wallPowerOffDelay = 1.2f; // Задержка перед отключением стены
    public Animator RedAnimator; // Ссылка на Animator робота
    public Animator YellowAnimator; // Ссылка на Animator стены
    private Collider2D robotColliderToDisable;
    private Collider2D wallColliderToDisable;
    private bool wallColliderDisabled = false; // Флаг для отслеживания состояния коллайдера стены
    public AudioClip correctPasswordAudio; // Аудиоклип для правильного пароля
    public AudioClip incorrectPasswordAudio;
    private AudioSource audioSource;

    private void Start()
    {
        robotColliderToDisable = objectWithRobotCollider.GetComponent<Collider2D>();
        wallColliderToDisable = objectWithWallCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);
        audioSource = gameObject.AddComponent<AudioSource>();

        // Запуск корутины для автоматического отключения коллайдера стены через заданное время
        StartCoroutine(AutoDisableWallCollider(90f));
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        if (inputPassword == correctPasswordRobot)
        {
            audioSource.PlayOneShot(correctPasswordAudio);
            canvasManager.HideTerminalInterface();
            Debug.Log("Доступ разрешен!");
            // Отключаем коллайдер робота
            if (robotColliderToDisable != null)
            {
                robotColliderToDisable.enabled = false;
            }
            // Останавливаем стрельбу робота
            gameController.SetShootingAllowed(false);

            // Запускаем последовательность анимаций для робота
            StartCoroutine(PlayRobotAnimationSequence());
        }
        else if (inputPassword == correctPasswordWall)
        {    audioSource.PlayOneShot(correctPasswordAudio);
            canvasManager.HideTerminalInterface();
            Debug.Log("Доступ разрешен!");

            // Запускаем последовательность анимаций для стены
            StartCoroutine(PlayWallAnimationSequence());
        }
        else
        {
            audioSource.PlayOneShot(incorrectPasswordAudio);
            Debug.Log("Неверный пароль!");
            passwordInput.text = ""; // Очищаем поле ввода
        }

      

    }

    private IEnumerator PlayRobotAnimationSequence()
    {
        RedAnimator.SetTrigger("RedIntered");
        yield return new WaitForSeconds(robotPowerOffDelay);
        robotAnimator.SetTrigger("PasswordEntered");

        // Здесь вы можете добавить дополнительные действия после анимации отключения робота
    }

    private IEnumerator PlayWallAnimationSequence()
    {
        YellowAnimator.SetTrigger("WallDisabled");
        yield return new WaitForSeconds(wallPowerOffDelay);
        wallAnimator.SetTrigger("WallDisable");

        // Ожидание завершения анимации
        float animationLength = wallAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        // Отключаем коллайдер стены, если он еще не был отключен
        DisableWallCollider();
    }

    private IEnumerator AutoDisableWallCollider(float delay)
    {
        // Ждем заданное время
        yield return new WaitForSeconds(delay);

        // Запускаем анимацию отключения стены
        YellowAnimator.SetTrigger("WallDisabled");
        yield return new WaitForSeconds(wallPowerOffDelay);
        wallAnimator.SetTrigger("WallDisable");

        // Ожидание завершения анимации
        float animationLength = wallAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        // Отключаем коллайдер стены, если он еще не был отключен
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
