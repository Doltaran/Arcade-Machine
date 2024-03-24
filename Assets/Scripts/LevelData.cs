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
        // ѕример заполнени€ массива с вариаци€ми чисел
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
            // ƒобавьте сюда другие вариации чисел по мере необходимости
        };
    }

    // ћетод дл€ получени€ текущей вариации числа дл€ текущего уровн€
    public string GetCurrentNumberVariation()
    {
        // ѕредположим, что мы хотим использовать номер уровн€ как индекс дл€ получени€ вариации числа
        int currentLevel = GameManager.instance.GetCurrentLevel(); // ѕредположим, что у нас есть класс GameManager с методом GetCurrentLevel(), который возвращает текущий уровень

        // ѕровер€ем, что текущий уровень находитс€ в допустимом диапазоне
        if (currentLevel >= 0 && currentLevel < numbersVariations.Length)
        {
            // ¬озвращаем текущую вариацию числа дл€ текущего уровн€
            return numbersVariations[currentLevel].binaryVariation;
        }
        else
        {
            Debug.LogWarning("Ќедопустимый уровень!");
            return "";
        }

    }
    // ћетод дл€ получени€ случайной вариации числа дл€ текущего уровн€
    public NumberVariations GetRandomVariation()
    {
        // ѕровер€ем, что массив вариаций не пустой
        if (numbersVariations.Length > 0)
        {
            // √енерируем случайный индекс из массива вариаций чисел
            int randomIndex = Random.Range(0, numbersVariations.Length);

            // ¬озвращаем выбранную случайную вариацию
            return numbersVariations[randomIndex];
        }
        else
        {
            Debug.LogError("ћассив вариаций чисел пуст!");
            return null; // »ли другое подход€щее значение, в зависимости от вашей логики
        }
    }

}
