using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Vector2 move;
    float moveX;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    private Animator anim;

    void Start()
    {
        speed = 500f;
        jumpSpeed = 15f;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0, jumpSpeed);
        }

        if (rb2d.velocity.x != 0) anim.speed = 0;
        else anim.speed = 1;
    }

    private void FixedUpdate()
    {
        //rb2d.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
}
