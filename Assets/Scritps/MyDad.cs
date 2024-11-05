using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDad : MonoBehaviour
{
    [SerializeField]
    float myDadSpeed = -2f;
    Rigidbody2D rb;
    bool myDadWalk = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (myDadWalk)
        {
         Vector3 vel = rb.velocity;
         vel.x = myDadSpeed;
         rb.velocity = vel;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         myDadWalk = true;
        }
    }
}   
