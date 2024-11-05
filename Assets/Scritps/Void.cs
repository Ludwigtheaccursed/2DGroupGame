using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("PlayerHitBox").GetComponent<PlayerHealth3>() != null)
        {
         GameObject.Find("PlayerHitBox").GetComponent<PlayerHealth3>().PlayerHealth = 0;
         Debug.Log("DiedToVoid");
        }
        if (GameObject.Find("PlayerHitBox").GetComponent<PlayerHealth2>() != null)
        {
            GameObject.Find("PlayerHitBox").GetComponent<PlayerHealth2>().PlayerHealth = 0;
            Debug.Log("DiedToVoid");
        }
        else {
            Debug.Log("eeee"); 
                }
    }
}
