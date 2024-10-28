using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchOneHand : MonoBehaviour
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
        if (Input.GetButtonDown("Fire1") && timer >= 1)
        {
            anim.SetTrigger("Punch0");
            timer = 0;
        }
    }
}
