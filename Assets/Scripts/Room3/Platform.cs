using UnityEngine;

public class Platform : MonoBehaviour
{
    public int platformNumber; // Номер платформы
    public bool disableColliderOnStart; // Флаг для отключения коллайдера при запуске сцены
    public Collider2D collider2D; // Ссылка на коллайдер платформы
}
