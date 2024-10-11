using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{
    [SerializeField]
    float EnemySpeed = 5f;
    float MoveDir = -1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.x = MoveDir * EnemySpeed;
        rb.velocity = vel;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            MoveDir *= -1;
        }
    }
}   
