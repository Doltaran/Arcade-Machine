using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CanvasManager canvasManager;
    public LayerMask terminalLayer; // ����, �� ������� ��������� ��������

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
}
