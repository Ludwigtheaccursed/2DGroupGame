using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GnomeSlap : MonoBehaviour
{
    [SerializeField]
    GameObject HandHitBox;
    [SerializeField]
    Animator anim;
    [SerializeField]
    float slapDelay = 0.5f;
    float slapTimer = 0;
    bool slap = false;
    bool justSlapped = false;
    void Start()
    {
        
    }
    void Update()
    {
        slapTimer += Time.deltaTime;
        if (slap && slapTimer >= slapDelay)
        {
            HandHitBox.layer = 8;
            justSlapped = true;
            slap = false;
            slapTimer = 0;
            anim.SetTrigger("Slap");
        } else if (justSlapped == true && slapTimer >= 0.5)
        {
            anim.SetTrigger("Idle");
            justSlapped = false;
            HandHitBox.layer = 9;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            slap = true;
            slapTimer = 0;
        }

    }
}
