using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour
{
    public Text numberText;
    public LevelData levelData; // ������ �� ������ LevelData

    void Start()
    {
        StartCoroutine(InitializeNumberDisplay());
    }

    IEnumerator InitializeNumberDisplay()
    {
        yield return new WaitForSeconds(0.1f); // �������� � 0.1 �������

        // �������� ��������� �������� ����� ��� �������� ������
        NumberVariations randomVariation = levelData.GetRandomVariation();
        GameManager.instance.SetCurrentLevel(randomVariation.number);
        // ���������� ��������� ���������� ����� �� ������
        numberText.text = randomVariation.number.ToString();
    }
}
