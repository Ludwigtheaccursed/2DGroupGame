using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPace : MonoBehaviour
{
    float paceDir = -1;
    public float paceSpeed = 4;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.x = paceDir * paceSpeed;
        rb.velocity = vel;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            paceDir *= -1;
        }
    }
}
