using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float jumpForce = 7f; // Сила прыжка
    public Transform groundCheck; // Точка для проверки нахождения на земле
    public LayerMask groundLayer; // Слой для определения земли
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Получаем ввод от игрока
        float moveX = Input.GetAxis("Horizontal");

        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Применяем движение по горизонтали
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Прыжок при нахождении на земле
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Поворот персонажа
        if (moveX < 0) // Движение влево
        {
            _spriteRenderer.flipX = true; // Отражаем по оси X
        }
        else if (moveX > 0) // Движение вправо
        {
            _spriteRenderer.flipX = false; // Не отражаем
        }



        // Обновление параметров анимации
        _animator.SetBool("is-ground", isGrounded);
        _animator.SetBool("is-running", Mathf.Abs(moveX) > 0);
    }
}