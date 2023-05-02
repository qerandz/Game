using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Me2 : MonoBehaviour
{
    public float jumpForce = 10f;    // сила прыжка кубика
    public Transform groundCheck;   // точка проверки, находится ли кубик на земле
    public LayerMask groundLayer;   // слой земли, с которым должен взаимодействовать кубик

    private Rigidbody2D rb;         // компонент Rigidbody2D кубика
    private bool isGrounded;        // флаг, находится ли кубик на земле
    private bool isJumping;         // флаг, был ли уже совершен первый прыжок
    public Text bonus;
    public GameObject dead;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // получаем ссылку на компонент Rigidbody2D
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
        // проверяем, находится ли кубик на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // обрабатываем прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;  // сбрасываем флаг двойного прыжка
        }
        else if (!isGrounded && !isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);  // обнуляем вертикальную скорость
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;  // устанавливаем флаг двойного прыжка
        }
    }
}
