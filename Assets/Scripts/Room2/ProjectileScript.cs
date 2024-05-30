using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed = 5f;
    public float destroyDelay = 2f;
    public float shootDelay = 0.5f; // �������� ����� ����������
    public GameObject projectilePrefab;

    private bool isShooting = false;
    private float lastShootTime;

    public void StartShooting()
    {
        isShooting = true;
        lastShootTime = Time.time; // ��������� ����� ���������� ��������
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Update()
    {
        if (isShooting && Time.time - lastShootTime >= shootDelay)
        {
            // ������� ����� ������ ������ ���� ������ �������� ����� ����������
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-projectileSpeed, 0f);

            Destroy(projectile, destroyDelay);

            lastShootTime = Time.time; // ��������� ����� ���������� ��������
        }
    }
}
