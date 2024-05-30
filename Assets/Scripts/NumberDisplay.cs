using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour
{
    public Text numberText;
    public LevelData levelData; // Ссылка на скрипт LevelData

    void Start()
    {
        StartCoroutine(InitializeNumberDisplay());
    }

    IEnumerator InitializeNumberDisplay()
    {
        yield return new WaitForSeconds(0.1f); // Задержка в 0.1 секунду

        // Получаем случайную вариацию числа для текущего уровня
        NumberVariations randomVariation = levelData.GetRandomVariation();
        GameManager.instance.SetCurrentLevel(randomVariation.number);
        // Отображаем случайное десятичное число на экране
        numberText.text = randomVariation.number.ToString();
    }
}
