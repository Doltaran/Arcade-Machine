using UnityEngine;

public class GameController : MonoBehaviour
{
    public ProjectileScript projectileScript; // Ссылка на скрипт управления снарядами
    private bool isShootingAllowed = true;

    private void Start()
    {
        StartShooting(); // Запускаем стрельбу при старте игры
    }

    private void StartShooting()
    {
        if (isShootingAllowed)
        {
            projectileScript.StartShooting();
        }
    }

    public void SetShootingAllowed(bool allowed)
    {
        isShootingAllowed = allowed;
        if (allowed)
        {
            StartShooting();
        }
        else
        {
            projectileScript.StopShooting();
        }
    }

}
