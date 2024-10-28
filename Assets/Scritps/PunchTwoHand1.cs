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
        if (Input.GetButtonDown("Fire1") && timer >= 0.5 && anim.GetBool("LastPunchL") == false)
        {
            anim.SetTrigger("Punch0");
            anim.SetBool("LastPunchL", true);
            timer = 0;
        }
        else if (Input.GetButtonDown("Fire1") && timer >= 0.5 && anim.GetBool("LastPunchL") == true)
        {
            anim.SetTrigger("Punch0");
            anim.SetBool("LastPunchL", false);
            timer = 0;
        }
    }
}
