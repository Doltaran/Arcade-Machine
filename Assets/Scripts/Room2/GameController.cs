using UnityEngine;

public class GameController : MonoBehaviour
{
    public ProjectileScript projectileScript; // ������ �� ������ ���������� ���������
    private bool isShootingAllowed = true;

    private void Start()
    {
        StartShooting(); // ��������� �������� ��� ������ ����
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
