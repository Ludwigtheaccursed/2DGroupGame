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
    float SlapForceDefalut;
    int ratGoofy;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SlapForceDefalut = SlapForce;
        ratGoofy = Random.Range(1, 101);
    }
    void Update()
    {
        PunchTimer += Time.deltaTime;
        PunchHoldTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && PunchTimer >= PunchSpeed && Time.timeScale == 1 || AlwaysPunch)
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
        
        if (collision.gameObject.layer == 8 && PunchHold && collision.gameObject.tag != "PreSchooler" && collision.gameObject.tag != "MyDad")
        {
        PunchHold = false;
        collision.gameObject.layer = 9;
        collision.GetComponent<SpriteRenderer>().sortingOrder = 100;
        collision.GetComponent<BoxCollider2D>().isTrigger = true;
        //collision.GetComponentInChildren<EnemyHealthJumpOnHead>().enabled = false;
        if (collision.GetComponent<EnemyPatrolAI>() != null)
            {
                collision.GetComponent<EnemyPatrolAI>().enabled = true;
            }
        if (collision.GetComponent<StreetRatAI>() != null && ratGoofy != 42)
            {
                collision.GetComponent<StreetRatAI>().enabled = false;
            }
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
        SlapForce = SlapForceDefalut;
        } else if (collision.gameObject.layer == 8 && PunchHold && collision.gameObject.tag == "PreSchooler")
        {
            collision.GetComponentInChildren<Animator>().SetBool("IsDead", true);
            collision.GetComponentInChildren<SludgeMonsterACS>().enabled = false;
            collision.GetComponent<EnemyPatrolAI>().enabled = false;
            collision.gameObject.layer = 9;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
        } else if (collision.gameObject.layer == 8 && PunchHold && collision.gameObject.tag == "MyDad")
        {
            collision.GetComponent<MyDad>().enabled = false;
            GameObject.Find("MyDadLegs").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("MyDadSprite").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TombStone").GetComponent<SpriteRenderer>().enabled = true;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
            collision.gameObject.layer = 9;
        }
    }
}
