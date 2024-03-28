using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TerminalManager3 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public PlatformManager platformManager; // Ссылка на менеджер платформ

    // Словарь для хранения соответствия между паролями и номерами платформ
    public Dictionary<string, int> platformPasswords;

    void Start()
    {
        confirmButton.onClick.AddListener(CheckPassword);

        // Инициализируем словарь и заполняем его данными
        platformPasswords = new Dictionary<string, int>();
        platformPasswords.Add("1", 1);
        platformPasswords.Add("10", 2);// Пример пароля и соответствующей платформы

        // Можно добавить другие пароли и платформы по мере необходимости
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;

        // Проверяем правильность введенного пароля и активируем соответствующую платформу
        if (platformPasswords.ContainsKey(inputPassword))
        {
            ActivatePlatform(platformPasswords[inputPassword]);
            Debug.Log("Платформа Активирована!");
        }
        else
        {
            Debug.Log("Неверный пароль!");
        }
    }

    // Метод для активации определенной платформы
    private void ActivatePlatform(int platformNumber)
    {
        platformManager.ActivatePlatform(platformNumber);
    }
}
