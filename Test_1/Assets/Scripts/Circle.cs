using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Text score;
    [SerializeField] private float maxSpeed;
    private Vector2 movementDirection;
    public GameObject dead;

    void Start()
    {
        rb.AddForce(new Vector2(1, 1) * maxSpeed, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        // Ограничиваем скорость по оси X и Y
        float limitedSpeedX = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float limitedSpeedY = Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed);
        // Устанавливаем новую скорость
        rb.velocity = new Vector2(limitedSpeedX, limitedSpeedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            score.text = (System.Convert.ToInt64(score.text) + 1).ToString();
        }
        if (collision.gameObject.tag == "Floor")
        {
            score.text = (System.Convert.ToInt64(score.text) - 10).ToString();
        }
        if (collision.gameObject.tag == "enemy")
        {
            dead.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}
