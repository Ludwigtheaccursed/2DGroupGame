using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchCode : MonoBehaviour
{
    [SerializeField]
    float SlapForce = 10f;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
        //collision.GetComponent<SpriteRenderer>().OrderinLayer = 100;
        collision.GetComponent<BoxCollider2D>().isTrigger = true;
        collision.GetComponentInChildren<EnemyHealthJumpOnHead>().enabled = false;
        collision.GetComponent<EnemyPatrolAI>().enabled = false;
        collision.GetComponent<EnemyDieSpinn>().enabled = true;
            
        Vector3 playerPosition = Player.transform.position;
        Vector3 collisionPosition = collision.transform.position;
        Vector3 SlapDirection = collisionPosition - playerPosition + new Vector3 (0,1 + Random.Range(-0.5f, 0.5f),0);
        SlapDirection.Normalize();
        collision.GetComponent<Rigidbody2D>().velocity = SlapDirection * SlapForce;
        Debug.Log("punched");
        }
    }
}
