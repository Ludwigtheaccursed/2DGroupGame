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
        Vector3 playerPosition = Player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponent<SpriteRenderer>.OrderInLayer = 100;
        //collision.gameObject.GetComponent<BoxCollider2D>.IsTrigger = true;
        Vector3 SlapDirection = collision.transform.position - Player.transform.position;

        collision.gameObject.GetComponent<Rigidbody2D>().velocity = SlapDirection * SlapForce * -1;
        Debug.Log("punched");
    }
}
