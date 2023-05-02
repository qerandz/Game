using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 dir = new Vector2(-1, 0);

    void FixedUpdate()
    {
        transform.Translate(dir.normalized * speed * Time.fixedDeltaTime);
    }
}
