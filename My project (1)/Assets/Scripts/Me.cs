using UnityEngine;

public class Me : MonoBehaviour
{
    public float moveSpeed = 5f;     // �������� ����������� ���������
    public float jumpForce = 10f;    // ���� ������ ���������
    public Transform groundCheck;   // ����� ��������, ��������� �� �������� �� �����
    public LayerMask groundLayer;   // ���� �����, � ������� ������ ����������������� ��������

    private Rigidbody2D rb;         // ��������� Rigidbody2D ���������
    private bool isGrounded;        // ����, ��������� �� �������� �� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // �������� ������ �� ��������� Rigidbody2D
    }

    void Update()
    {
        // ���������, ��������� �� �������� �� �����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // �������� �������� ��� ����� ����������� (-1, 0 ��� 1)
        float horizontal = Input.GetAxisRaw("Horizontal");

        // ���������� ��������� �� �����������
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // ������������ ������
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
