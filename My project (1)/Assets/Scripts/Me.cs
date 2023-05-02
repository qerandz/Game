using UnityEngine;

public class Me : MonoBehaviour
{
    public float moveSpeed = 5f;     // скорость перемещения персонажа
    public float jumpForce = 10f;    // сила прыжка персонажа
    public Transform groundCheck;   // точка проверки, находится ли персонаж на земле
    public LayerMask groundLayer;   // слой земли, с которым должен взаимодействовать персонаж

    private Rigidbody2D rb;         // компонент Rigidbody2D персонажа
    private bool isGrounded;        // флаг, находится ли персонаж на земле

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // получаем ссылку на компонент Rigidbody2D
    }

    void Update()
    {
        // проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // получаем значение оси ввода горизонтали (-1, 0 или 1)
        float horizontal = Input.GetAxisRaw("Horizontal");

        // перемещаем персонажа по горизонтали
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // обрабатываем прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
