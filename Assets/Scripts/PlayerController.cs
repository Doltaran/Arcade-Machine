using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CanvasManager canvasManager;
    public LayerMask terminalLayer; // ����, �� ������� ��������� ��������
    public Animator animator;
    bool terminalOpened = false;
    Transform terminalTransform;
    float maxDistance = 1f; // ������������ ����������, �� ������� ��������� ����� ������

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
        // ���������, ���� ������, � ������� ���������� ��������, ����� ��� "Bullet"
        if (collision.CompareTag("Bullet"))
        {
            // ���������� ������
            StartCoroutine(HandleDeath());
        }
    }

    IEnumerator HandleDeath()
    {
        // ������������� �������� ������
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            Debug.LogError("Animator is not assigned!");
        }

        // ���� ���������� �������� (��������������, ��� �������� ������ 1 �������)
        yield return new WaitForSeconds(0.5f);

        // ���������� ������
        RestartLevel();
    }



    void RestartLevel()
    {
        // ������������� ������� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
