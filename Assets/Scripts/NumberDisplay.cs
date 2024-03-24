using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour
{
    public Text numberText;
    public LevelData levelData; // ������ �� ������ LevelData

    void Start()
    {
        // �������� ��������� �������� ����� ��� �������� ������
        NumberVariations randomVariation = levelData.GetRandomVariation();
        GameManager.instance.SetCurrentLevel(randomVariation.number);
        // ���������� ��������� ���������� ����� �� ������
        numberText.text = randomVariation.number.ToString();
    }
}
