using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 5f;
    [SerializeField]
    float JumpForce = 3f;
    bool Grounded = false;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField]
    float ExtraGravSpeed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * MoveSpeed;
        rb.velocity = velocity;
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            rb.AddForce(new Vector2(0, 10 * JumpForce));
            Grounded = false;
        }
        if (!Input.GetButton("Jump") || rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0, -ExtraGravSpeed));
        }
        anim.SetFloat("y", velocity.y);
        anim.SetBool("grounded", Grounded);
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Grounded = false;
        }
    }
}
