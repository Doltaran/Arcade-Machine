using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Platform[] platforms; // Массив платформ

    void Start()
    {
        // Отключаем коллайдеры для выбранных платформ
        DisableColliders();
    }

    // Метод для отключения коллайдеров у выбранных платформ
    private void DisableColliders()
    {
        foreach (Platform platform in platforms)
        {
            if (platform.disableColliderOnStart)
            {
                platform.collider2D.enabled = false;
            }
        }
    }

    // Метод для активации коллайдера у выбранной платформы
    public void ActivatePlatform(int platformNumber)
    {
        foreach (Platform platform in platforms)
        {
            if (platform.platformNumber == platformNumber)
            {
                platform.collider2D.enabled = true;
                break;
            }
        }
    }
}
