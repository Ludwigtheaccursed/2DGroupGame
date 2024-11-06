using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 10f;
    [SerializeField]
    float JumpForce = 1.15f;
    bool Grounded = false;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField]
    float ExtraGravSpeed = 0.015f;
    [SerializeField]
    float maxFallSpeed = 100;
    [SerializeField]
    GameObject PlayerFist;
    bool Fliped = false;
    [SerializeField]
    GameObject ChairBase;
    [SerializeField]
    GameObject ArmSprite;
    Vector2 velocity;
    float FistOffset;
    Vector2 FistOffsetPos;
    [SerializeField]
    GameObject SunGlasses;
    [SerializeField]
    GameObject PlayerHat0;
    [SerializeField]
    GameObject PlayerHat1;
    [SerializeField]
    GameObject PlayerHat2;
    [SerializeField]
    GameObject PlayerHat3;
    [SerializeField]
    GameObject PlayerHat4;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        velocity = rb.velocity;
        velocity.x = moveX * MoveSpeed;
        FistOffsetPos = PlayerFist.GetComponent<BoxCollider2D>().offset;
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
        //Flip position code for player sprites
        if (GetComponent<SpriteRenderer>().flipX && !Fliped)
        {
            float xVal = PlayerFist.transform.localPosition.x;
            xVal *= -1;
            PlayerFist.transform.localPosition = new Vector2(xVal, PlayerFist.transform.localPosition.y);
            FistOffset = FistOffsetPos.x;
            FistOffset *= -1;
            FistOffsetPos = new Vector2(FistOffset, FistOffsetPos.y);

            float xVal2 = ArmSprite.transform.localPosition.x;
            xVal2 *= -1;
            ArmSprite.transform.localPosition = new Vector2(xVal2, ArmSprite.transform.localPosition.y);
            ArmSprite.GetComponent<SpriteRenderer>().flipX = true;

            ChairBase.GetComponent<SpriteRenderer>().flipX = true;

            if (PlayerHat0 != null)
            {
                PlayerHat0.GetComponent<SpriteRenderer>().flipX = false;
                PlayerHat1.GetComponent<SpriteRenderer>().flipX = false;
                PlayerHat2.GetComponent<SpriteRenderer>().flipX = false;
                PlayerHat3.GetComponent<SpriteRenderer>().flipX = false;
                PlayerHat4.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (SunGlasses.GetComponent<EnemyDieSpinn>().enabled == false)
            {
             float xVal3 = SunGlasses.transform.localPosition.x;
             xVal3 *= -1;
             SunGlasses.transform.localPosition = new Vector2(xVal3, SunGlasses.transform.localPosition.y);
             SunGlasses.GetComponent<SpriteRenderer>().flipX = true;
            }
            Fliped = true;
        }
        if (!GetComponent<SpriteRenderer>().flipX && Fliped)
        {

            float xVal = PlayerFist.transform.localPosition.x;
            xVal *= -1;
            PlayerFist.transform.localPosition = new Vector2(xVal, PlayerFist.transform.localPosition.y);
            FistOffset = FistOffsetPos.x;
            FistOffset *= -1;
            FistOffsetPos = new Vector2(FistOffset, FistOffsetPos.y);

            float xVal2 = ArmSprite.transform.localPosition.x;
            xVal2 *= -1;
            ArmSprite.transform.localPosition = new Vector2(xVal2, ArmSprite.transform.localPosition.y);
            
            ArmSprite.GetComponent<SpriteRenderer>().flipX = false;
            
            if (SunGlasses.GetComponent<EnemyDieSpinn>().enabled == false)
            {
             float xVal3 = SunGlasses.transform.localPosition.x;
             xVal3 *= -1;
             SunGlasses.transform.localPosition = new Vector2(xVal3, SunGlasses.transform.localPosition.y);
             SunGlasses.GetComponent<SpriteRenderer>().flipX = false;
            }

            ChairBase.GetComponent<SpriteRenderer>().flipX = false;

            if(PlayerHat0 != null)
            {
             PlayerHat0.GetComponent<SpriteRenderer>().flipX = true;
             PlayerHat1.GetComponent<SpriteRenderer>().flipX = true;
             PlayerHat2.GetComponent<SpriteRenderer>().flipX = true;
             PlayerHat3.GetComponent<SpriteRenderer>().flipX = true;
             PlayerHat4.GetComponent<SpriteRenderer>().flipX = true;
            }
            Fliped = false;
        }
        PlayerFist.GetComponent<BoxCollider2D>().offset = FistOffsetPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
        /*if(collision.gameObject.tag == "EnemyHead")
        {
            velocity.y = 10 * JumpForce;
            rb.velocity = velocity;
        }*/
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
