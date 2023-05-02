using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Me2 : MonoBehaviour
{
    public float jumpForce = 10f;    // ���� ������ ������
    public Transform groundCheck;   // ����� ��������, ��������� �� ����� �� �����
    public LayerMask groundLayer;   // ���� �����, � ������� ������ ����������������� �����

    private Rigidbody2D rb;         // ��������� Rigidbody2D ������
    private bool isGrounded;        // ����, ��������� �� ����� �� �����
    private bool isJumping;         // ����, ��� �� ��� �������� ������ ������
    public Text bonus;
    public GameObject dead;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // �������� ������ �� ��������� Rigidbody2D
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="freespins")
        {
            bonus.text = (System.Convert.ToInt64(bonus.text) + 1).ToString();
            Destroy(collision.gameObject);            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            dead.SetActive(true);
            Time.timeScale = 0f;           
        }
    }
    void Update()
    {
        // ���������, ��������� �� ����� �� �����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // ������������ ������
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;  // ���������� ���� �������� ������
        }
        else if (!isGrounded && !isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);  // �������� ������������ ��������
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;  // ������������� ���� �������� ������
        }
    }
}
