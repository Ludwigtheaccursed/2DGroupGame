using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeACS : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    BoxCollider2D bc;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        bc = gameObject.GetComponentInParent<BoxCollider2D>();
    } //"you see me deailing this chair's butt" - Jessie
    void Update()
    {
        if (rb.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            bc.offset.Equals(-1 * bc.offset) ;
        }
        if (rb.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            bc.offset.Equals(-1 * bc.offset);
        }
        if (gameObject.GetComponentInParent<EnemyDieSpinn>().enabled == true)
        {
            anim.SetBool("IsDead", true);
        }
    }
}
