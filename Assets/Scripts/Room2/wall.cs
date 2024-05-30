using UnityEngine;

public class Wall : MonoBehaviour
{
    // Эффект, который вы хотите применить к стене при попадании снаряда
    public GameObject hitEffect;

    // Метод, вызываемый при столкновении снаряда со стеной
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли снаряд со стеной
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Создаём эффект попадания снаряда
            if (hitEffect != null)
            {
                Instantiate(hitEffect, collision.GetContact(0).point, Quaternion.identity);
            }

            // Уничтожаем снаряд
            Destroy(collision.gameObject);
        }
    }
}
