using UnityEngine;

[System.Serializable]
public class NumberVariations
{
    public int number;
    public string binaryVariation;

    public NumberVariations(int num, string binary)
    {
        number = num;
        binaryVariation = binary;
    }


}

public class LevelData : MonoBehaviour
{
    public NumberVariations[] numbersVariations;



    void Start()
    {
        // ������ ���������� ������� � ���������� �����
        numbersVariations = new NumberVariations[]
        {
            new NumberVariations(0, "0"),
            new NumberVariations(1, "1"),
            new NumberVariations(2, "10"),
            new NumberVariations(3, "11"),
            new NumberVariations(4, "100"),
            new NumberVariations(5, "101"),
            new NumberVariations(6, "110"),
            new NumberVariations(7, "111")
            // �������� ���� ������ �������� ����� �� ���� �������������
        };
    }

    // ����� ��� ��������� ������� �������� ����� ��� �������� ������
    public string GetCurrentNumberVariation()
    {
        // �����������, ��� �� ����� ������������ ����� ������ ��� ������ ��� ��������� �������� �����
        int currentLevel = GameManager.instance.GetCurrentLevel(); // �����������, ��� � ��� ���� ����� GameManager � ������� GetCurrentLevel(), ������� ���������� ������� �������

        // ���������, ��� ������� ������� ��������� � ���������� ���������
        if (currentLevel >= 0 && currentLevel < numbersVariations.Length)
        {
            // ���������� ������� �������� ����� ��� �������� ������
            return numbersVariations[currentLevel].binaryVariation;
        }
        else
        {
            Debug.LogWarning("������������ �������!");
            return "";
        }

    }
    // ����� ��� ��������� ��������� �������� ����� ��� �������� ������
    public NumberVariations GetRandomVariation()
    {
        // ���������, ��� ������ �������� �� ������
        if (numbersVariations.Length > 0)
        {
            // ���������� ��������� ������ �� ������� �������� �����
            int randomIndex = Random.Range(0, numbersVariations.Length);

            // ���������� ��������� ��������� ��������
            return numbersVariations[randomIndex];
        }
        else
        {
            Debug.LogError("������ �������� ����� ����!");
            return null; // ��� ������ ���������� ��������, � ����������� �� ����� ������
        }
    }

}
