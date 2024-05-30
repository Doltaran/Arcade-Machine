using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ���������
    public float jumpForce = 7f; // ���� ������
    public Transform groundCheck; // ����� ��� �������� ���������� �� �����
    public LayerMask groundLayer; // ���� ��� ����������� �����
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
        // �������� ���� �� ������
        float moveX = Input.GetAxis("Horizontal");

        // ���������, ��������� �� �������� �� �����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // ��������� �������� �� �����������
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // ������ ��� ���������� �� �����
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // ������� ���������
        if (moveX < 0) // �������� �����
        {
            _spriteRenderer.flipX = true; // �������� �� ��� X
        }
        else if (moveX > 0) // �������� ������
        {
            _spriteRenderer.flipX = false; // �� ��������
        }



        // ���������� ���������� ��������
        _animator.SetBool("is-ground", isGrounded);
        _animator.SetBool("is-running", Mathf.Abs(moveX) > 0);
    }
}