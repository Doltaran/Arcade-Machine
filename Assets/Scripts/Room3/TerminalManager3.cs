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

    void Start()
    {
        confirmButton.onClick.AddListener(CheckPassword);

        // �������������� ������� � ��������� ��� �������
        platformPasswords = new Dictionary<string, int>();
        platformPasswords.Add("1", 1);
        platformPasswords.Add("10", 2);// ������ ������ � ��������������� ���������

        // ����� �������� ������ ������ � ��������� �� ���� �������������
    }

    public void CheckPassword()
    {
        string inputPassword = passwordInput.text;

        // ��������� ������������ ���������� ������ � ���������� ��������������� ���������
        if (platformPasswords.ContainsKey(inputPassword))
        {
            ActivatePlatform(platformPasswords[inputPassword]);
            Debug.Log("��������� ������������!");
        }
        else
        {
            Debug.Log("�������� ������!");
        }
    }

    // ����� ��� ��������� ������������ ���������
    private void ActivatePlatform(int platformNumber)
    {
        platformManager.ActivatePlatform(platformNumber);
    }
}
