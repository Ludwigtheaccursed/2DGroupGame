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
    [SerializeField]
    float maxFallSpeed = 6;
    [SerializeField]
    GameObject PlayerFist;
    bool Fliped = false;

    Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // MOVEMENT
        float moveX = Input.GetAxis("Horizontal");
        velocity = rb.velocity;
        velocity.x = moveX * MoveSpeed;
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            velocity.y = 10 * JumpForce;
            Grounded = false;
        }
        if (!Input.GetButton("Jump") || rb.velocity.y < 0)
        {
            velocity.y += -ExtraGravSpeed;
        }

        if (velocity.y > maxFallSpeed)
        {
            velocity.y = maxFallSpeed;
        }

        rb.velocity = velocity;

        // ANIMATIONS,UNCOMMENT WHEN NEEDED!
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
        //Flip position code for player fists
        if (GetComponent<SpriteRenderer>().flipX && !Fliped)
        {
            float xVal = PlayerFist.transform.localPosition.x;
            xVal *= -1;
            PlayerFist.transform.localPosition = new Vector2(xVal, PlayerFist.transform.localPosition.y);
            Fliped = true;
        }
        if (!GetComponent<SpriteRenderer>().flipX && Fliped)
        {

            float xVal = PlayerFist.transform.localPosition.x;
            xVal *= -1;
            PlayerFist.transform.localPosition = new Vector2(xVal, PlayerFist.transform.localPosition.y);
            Fliped = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
        if(collision.gameObject.tag == "EnemyHead")
        {
            velocity.y = 10 * JumpForce;
            rb.velocity = velocity;
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
