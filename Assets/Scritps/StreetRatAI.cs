using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StreetRatAI : MonoBehaviour
{
    [SerializeField]
    float chaseSpeed = 5f;
    [SerializeField]
    float chaseDistance = 7f;
    [SerializeField]
    float chaseDistanceVert = 3f;
    GameObject player;
    Animator anim;
    SpriteRenderer RatSprite;
    int vel;
    Vector3 playerPos;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.Find("RatSprite").GetComponent<Animator>();
        RatSprite = transform.Find("RatSprite").GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        int rana = Random.Range(1, 200);
        if (rana == 7) {
            anim.SetTrigger("FlinchTrigger");
        }
        vel = (int)GetComponent<Rigidbody2D>().velocity.x;
        playerPos = player.transform.position;
        anim.SetInteger("X", vel);
        if (playerPos.x - transform.position.x >= 1)
        {
            RatSprite.flipX = true;
        }
        if (playerPos.x - transform.position.x <= 1)
        {
            RatSprite.flipX = false;
        }
        if (playerPos.x - transform.position.x <= chaseDistance && playerPos.y -transform.position.y <= chaseDistanceVert)
        {
            Vector3 movedir = playerPos - transform.position;
            movedir.Normalize();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(movedir.x * chaseSpeed, 0 ,0);
        }
    }
}
