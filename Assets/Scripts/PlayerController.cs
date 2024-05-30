using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CanvasManager canvasManager;
    public LayerMask terminalLayer; // Слой, на котором находится терминал
    public Animator animator;
    bool terminalOpened = false;
    Transform terminalTransform;
    float maxDistance = 1f; // Максимальное расстояние, на котором интерфейс будет открыт

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f, terminalLayer);

            if (colliders.Length > 0)
            {
                if (terminalOpened)
                {
                    canvasManager.HideTerminalInterface();
                    terminalOpened = false;
                }
                else
                {
                    canvasManager.ShowTerminalInterface();
                    terminalOpened = true;
                    terminalTransform = colliders[0].transform;
                }
            }
        }

        if (terminalOpened && Vector2.Distance(transform.position, terminalTransform.position) > maxDistance)
        {
            canvasManager.HideTerminalInterface();
            terminalOpened = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если объект, с которым столкнулся персонаж, имеет тег "Bullet"
        if (collision.CompareTag("Bullet"))
        {
            // Перезапуск уровня
            StartCoroutine(HandleDeath());
        }
    }

    IEnumerator HandleDeath()
    {
        // Воспроизводим анимацию смерти
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            Debug.LogError("Animator is not assigned!");
        }

        // Ждем завершения анимации (предполагается, что анимация длится 1 секунду)
        yield return new WaitForSeconds(0.5f);

        // Перезапуск уровня
        RestartLevel();
    }



    void RestartLevel()
    {
        // Перезапускаем текущий уровень
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
