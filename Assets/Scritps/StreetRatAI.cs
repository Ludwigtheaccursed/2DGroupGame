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
    GameObject player;
    Animator anim;
    int vel;
    Vector3 playerPos;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        vel =  (int)GetComponent<Rigidbody2D>().velocity.x;
        
    }
    void Update()
    {
        playerPos = player.transform.position;
        anim.SetFloat("X", vel);
        if (playerPos.x - transform.position.x <= chaseDistance)
        {
            Vector3 movedir = playerPos - transform.position;
            movedir.Normalize();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(movedir.x * chaseSpeed, 0 ,0);
        }
    }
}
