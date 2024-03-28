using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed = 5f;
    public float destroyDelay = 2f;
    public GameObject projectilePrefab;

    // Новый метод для начала стрельбы
    public void StartShooting()
    {
        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-projectileSpeed, 0f);

            yield return new WaitForSeconds(destroyDelay);

            Destroy(projectile);
        }
    }
}

