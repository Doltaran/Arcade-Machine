using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool correctPasswordEntered { get; private set; } // Флаг для проверки введенного правильного пароля
    public ProjectileScript projectileScript; // Ссылка на скрипт управления снарядами
    private int currentLevelNumber = 0;
    private void Start()
    {
        correctPasswordEntered = false; // Изначально флаг устанавливаем в false
    }

    public void SetCorrectPasswordEntered(bool value)
    {
        correctPasswordEntered = value;
    }

    // Добавим метод, который будет управлять снарядами
    public void ControlProjectiles()
    {
        if (correctPasswordEntered)
        {
            projectileScript.StartShooting(); // Запускаем снаряды, если правильный пароль введен
        }
    }


}
