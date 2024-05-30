using UnityEngine;

public class Wall : MonoBehaviour
{
    // ������, ������� �� ������ ��������� � ����� ��� ��������� �������
    public GameObject hitEffect;

    // �����, ���������� ��� ������������ ������� �� ������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ���������� �� ������ �� ������
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // ������ ������ ��������� �������
            if (hitEffect != null)
            {
                Instantiate(hitEffect, collision.GetContact(0).point, Quaternion.identity);
            }

            // ���������� ������
            Destroy(collision.gameObject);
        }
    }
}
