using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float jumpForce = 7f; // Сила прыжка
    public Transform groundCheck; // Точка для проверки нахождения на земле
    public LayerMask groundLayer; // Слой для определения земли

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Получаем ввод от игрока
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Применяем движение по горизонтали
        Vector2 movement = new Vector2(moveX, 0).normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Прыжок при нахождении на земле
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
