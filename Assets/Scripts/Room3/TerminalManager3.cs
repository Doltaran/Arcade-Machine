using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TerminalManager3 : MonoBehaviour
{
    public InputField passwordInput;
    public Button confirmButton;
    public PlatformManager platformManager; // ������ �� �������� ��������
    public AudioClip incorrectPasswordAudio; // ��������� ��� ������������� ������
    private AudioSource audioSource;

    // ������� ��� �������� ������������ ����� �������� � �������� ��������
    public Dictionary<string, int> platformPasswords;

    public Sprite activeSprite; // ������ ��� �������������� ���������

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        confirmButton.onClick.AddListener(CheckPassword);

        // �������������� ������� � ��������� ��� �������
        platformPasswords = new Dictionary<string, int>();
        platformPasswords.Add("101", 0);
        platformPasswords.Add("100", 1);
        platformPasswords.Add("1000", 2);
        platformPasswords.Add("1111", 3);
        platformPasswords.Add("10101", 4);// ������ ������ � ��������������� ���������

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
            audioSource.PlayOneShot(incorrectPasswordAudio);
            Debug.Log("�������� ������!");
        }
    }
}
