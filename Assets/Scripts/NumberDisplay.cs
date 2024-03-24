using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour
{
    public Text numberText;
    public LevelData levelData; // Ссылка на скрипт LevelData

    void Start()
    {
        // Получаем случайную вариацию числа для текущего уровня
        NumberVariations randomVariation = levelData.GetRandomVariation();
        GameManager.instance.SetCurrentLevel(randomVariation.number);
        // Отображаем случайное десятичное число на экране
        numberText.text = randomVariation.number.ToString();
    }
}
