using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchCode : MonoBehaviour
{
    [SerializeField]
    float PunchSpeed = 1f;
    [SerializeField]
    float SlapForce = 10f;
    GameObject Player;
    float PunchTimer;
    float PunchHoldTime;
    bool PunchHold = false;
    [SerializeField]
    bool AlwaysPunch = false;
    float SlapForceeee;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SlapForceeee = SlapForce;
    }
    void Update()
    {
        PunchTimer += Time.deltaTime;
        PunchHoldTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && PunchTimer >= PunchSpeed || AlwaysPunch)
        {
            PunchTimer = 0;
            PunchHoldTime = 0;
            PunchHold = true;
        }
        if (PunchHoldTime >= 0.2)
        {
            PunchHold = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && PunchHold)
        {
        PunchHold = false;
        collision.GetComponent<SpriteRenderer>().sortingOrder = 100;
        collision.GetComponent<BoxCollider2D>().isTrigger = true;
        //collision.GetComponentInChildren<EnemyHealthJumpOnHead>().enabled = false;
        collision.GetComponent<EnemyPatrolAI>().enabled = false;
        collision.GetComponent<EnemyDieSpinn>().enabled = true;
        collision.GetComponent<EnemyDelete>().enabled = true;
        Vector3 playerPosition = Player.transform.position;
        Vector3 collisionPosition = collision.transform.position;
        Vector3 SlapDirection = collisionPosition - playerPosition + new Vector3 (0,1 + Random.Range(-0.5f, 0.5f),0);
        SlapDirection.Normalize();
        int random = Random.Range(1, 101);
            if (random == 42)
            {
                SlapForce = 100;
            }
            else { 
                SlapForce += Random.Range(-5, 5);
            }
        collision.GetComponent<Rigidbody2D>().velocity = SlapDirection * SlapForce;
        SlapForce = SlapForceeee;
        }
    }
}
