using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    public float speed = 1f;

    public Vector2 _direction = new Vector2(1,1);



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixefUpdate()
    {
        Vector2 position = transform.position;
        Vector2 translation = _direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(translation + position);
    }
}
