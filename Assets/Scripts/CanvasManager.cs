using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject inputField;
    public GameObject button;
    public GameObject image;

    void Start()
    {
        // �������� ������� ��� ������ �����
        inputField.SetActive(false);
        button.SetActive(false);
        image.SetActive(false);
    }

    // �������� ������ ��� ����������� � ������� �������� � ������ ������, ����� ����� �������� � ���������
    public void ShowTerminalInterface()
    {
        inputField.SetActive(true);
        button.SetActive(true);
        image.SetActive(true);
        
    }

    public void HideTerminalInterface()
    {
        inputField.SetActive(false);
        button.SetActive(false);
        image.SetActive(false);

    }
    public void ToggleTerminalInterface()
    {
        inputField.SetActive(!inputField.activeSelf);
        button.SetActive(!button.activeSelf);
        image.SetActive(!image.activeSelf);
    }
}
