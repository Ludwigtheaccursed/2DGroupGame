using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEditor.Tilemaps;
using UnityEngine;

public class KinderACS : MonoBehaviour
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
        if (rb.velocity.x > 0 && anim.GetBool("isDead") == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (rb.velocity.x < 0 && anim.GetBool("isDead") == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (gameObject.GetComponentInParent<EnemyDieSpinn>().enabled == true)
        {
            anim.SetBool("IsDead", true);
        }
    }
}
