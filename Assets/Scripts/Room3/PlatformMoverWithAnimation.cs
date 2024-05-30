using UnityEngine;

public class PlatformMoverWithAnimation : MonoBehaviour
{
    public Animator animator; // Ссылка на Animator платформы
    public LayerMask playerLayer; // Слой игрока для обнаружения

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            animator.SetTrigger("RaisePlatform");
        }
    }
}
