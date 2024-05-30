using UnityEngine;
using UnityEngine.UI;

public class TerminalManager1 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public CanvasManager canvasManager;

    public GameObject objectWithCollider;
    private Collider2D colliderToDisable;
    private LevelData levelData; // Ссылка на экземпляр LevelData
    public Animator animator;
    public AudioClip correctPasswordAudio; // Аудиоклип для правильного пароля
    public AudioClip incorrectPasswordAudio; // Аудиоклип для неправильного пароля
    private AudioSource audioSource;

    private void Start()
    {
        colliderToDisable = objectWithCollider.GetComponent<Collider2D>();
        confirmButton.onClick.AddListener(CheckPassword);

        // Получаем доступ к экземпляру LevelData на сцене
        levelData = FindObjectOfType<LevelData>();

        // Инициализация AudioSource компонента
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;
        string correctPassword = GetCorrectPassword(); // Получаем правильный ответ из LevelData

        if (inputPassword == correctPassword)
        {
            canvasManager.HideTerminalInterface();
            Debug.Log("Доступ разрешен!");
            animator.SetTrigger("PasswordInput");
            animator.Play("PasswordInput");
            if (colliderToDisable != null)
            {
                colliderToDisable.enabled = false;
            }

            // Воспроизводим аудио для правильного пароля
            if (correctPasswordAudio != null)
            {
                audioSource.PlayOneShot(correctPasswordAudio);
            }
        }
        else
        {
            Debug.Log("Неверный пароль!");
            passwordInput.text = "";

            // Воспроизводим аудио для неправильного пароля
            if (incorrectPasswordAudio != null)
            {
                audioSource.PlayOneShot(incorrectPasswordAudio);
            }
        }
    }

    // Метод для получения правильного ответа из LevelData
    private string GetCorrectPassword()
    {
        if (levelData != null)
        {
            // Проверяем текущий уровень и получаем соответствующий ответ из LevelData
            return levelData.GetCurrentNumberVariation();
        }
        else
        {
            Debug.LogError("LevelData не найден на сцене!");
            return ""; // Возвращаем пустую строку в случае ошибки
        }
    }
}
