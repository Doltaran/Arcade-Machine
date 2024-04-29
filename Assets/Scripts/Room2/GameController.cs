using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool correctPasswordEntered { get; private set; } // ���� ��� �������� ���������� ����������� ������
    public ProjectileScript projectileScript; // ������ �� ������ ���������� ���������
    private void Start()
    {
        correctPasswordEntered = false; // ���������� ���� ������������� � false
    }

    public void SetCorrectPasswordEntered(bool value)
    {
        correctPasswordEntered = value;
    }

    // ������� �����, ������� ����� ��������� ���������
    public void ControlProjectiles()
    {
        if (correctPasswordEntered)
        {
            projectileScript.StartShooting(); // ��������� �������, ���� ���������� ������ ������
        }
    }


}
