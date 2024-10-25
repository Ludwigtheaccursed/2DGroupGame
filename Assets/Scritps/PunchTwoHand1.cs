using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTwoHand : MonoBehaviour
{
    Animator anim;
    float timer = 0;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= 0.5 && anim.GetBool("LastPunchLeft") == false)
        {
            anim.SetTrigger("Punch0");
            anim.SetBool("LastPunchLeft", true);
        }
        if (Input.GetButtonDown("Fire1") && timer >= 0.5 && anim.GetBool("LastPunchLeft") == true)
        {
            anim.SetTrigger("Punch0");
            anim.SetBool("LastPunchLeft", false);
        }
    }
}
