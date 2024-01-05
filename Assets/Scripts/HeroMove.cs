using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ���������
    public float jumpForce = 7f; // ���� ������
    public Transform groundCheck; // ����� ��� �������� ���������� �� �����
    public LayerMask groundLayer; // ���� ��� ����������� �����

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �������� ���� �� ������
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ���������, ��������� �� �������� �� �����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // ��������� �������� �� �����������
        Vector2 movement = new Vector2(moveX, 0).normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // ������ ��� ���������� �� �����
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
