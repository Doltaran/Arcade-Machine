using UnityEngine;
using UnityEngine.UI;

public class TerminalManager2 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public string correctPassword = "1101"; // Пароль для проверки
    public CanvasManager canvasManager;
    public GameController gameController; // Добавляем GameController
    public GameObject objectWithCollider; // Ссылка на объект с коллайдером
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
            Debug.Log("Доступ разрешен!");
            // Добавьте здесь логику для отключения робота или что-то подобное
            if (colliderToDisable != null)
            {
                colliderToDisable.enabled = false;
                // Collider теперь отключен
            }

        }
        else
        {   // Устанавливаем флаг в GameController, что не правильный пароль введен
            gameController.SetCorrectPasswordEntered(true);
            // Вызываем метод для управления снарядами в GameController
            gameController.ControlProjectiles();
            Debug.Log("Неверный пароль!"); // Выводим сообщение об ошибке в консоль
            passwordInput.text = ""; // Очищаем поле ввода
        }
    }
}