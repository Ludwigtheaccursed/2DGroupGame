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
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth3>() != null)
        {
         GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth3>().PlayerHealth = 0;
         Debug.Log("DiedToVoid");
        }
    }
}
