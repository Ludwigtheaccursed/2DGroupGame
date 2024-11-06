using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoorWin : MonoBehaviour
{
    [SerializeField]
    GameObject levelCompleteCanvase;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelCompleteCanvase.GetComponent<Canvas>().enabled = true;
        }
    }

}
