using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongleCubePickup : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerFloorHitBox")
        {
            Debug.Log("THE BONGLUS CUBE HAS BEEN COLLECTED");
            BongleCubeCount.BongleCubesCollected += 1;
            Debug.Log("YOU HAVE COLLECTED " + BongleCubeCount.BongleCubesCollected + "  BONGLUS CUBES SO FAR");
            Destroy(gameObject);
        }
    }
}
