using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TerminalManager3 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public PlatformManager platformManager; // ������ �� �������� ��������

    // ������� ��� �������� ������������ ����� �������� � �������� ��������
    public Dictionary<string, int> platformPasswords;

    public Sprite activeSprite; // ������ ��� �������������� ���������

    void Start()
    {
        confirmButton.onClick.AddListener(CheckPassword);

        // �������������� ������� � ��������� ��� �������
        platformPasswords = new Dictionary<string, int>();
        platformPasswords.Add("1", 1);
        platformPasswords.Add("10", 2);
        platformPasswords.Add("100", 4);
        platformPasswords.Add("101", 5);// ������ ������ � ��������������� ���������

        // ����� �������� ������ ������ � ��������� �� ���� �������������
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;

        // ��������� ������������ ���������� ������ � ���������� ��������������� ���������
        if (platformPasswords.ContainsKey(inputPassword))
        {
            int platformNumber = platformPasswords[inputPassword];
            platformManager.ActivatePlatform(platformNumber);
            platformManager.SetPlatformSprite(platformNumber, activeSprite); // �������� ����� ������
            Debug.Log("������ ��������!");
        }
        else
        {
            Debug.Log("�������� ������!");
        }
    }
}
