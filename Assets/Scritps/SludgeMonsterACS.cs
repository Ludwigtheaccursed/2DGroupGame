using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeMonsterACS : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }
    void Update()
    {
        if (rb.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (rb.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (gameObject.GetComponentInParent<EnemyDieSpinn>().enabled == true)
        {
            anim.SetBool("IsDead", true);
            Debug.Log("WHY");
        }
    }
}
