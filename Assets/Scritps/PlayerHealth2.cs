using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth2 : MonoBehaviour
{
    float PlayerHealth = 2;
    GameObject SunGlasses;
    bool Iframes = false;
    [SerializeField]
    float IframeDuration = 1;
    float IframeTimer;
    [SerializeField]
    float SunGlassesSpinSpeed = 1;
    float RanRot;
    void Start()
    {
        SunGlasses = GameObject.FindGameObjectWithTag("VERYCOOLSUNGLASES");
        IframeTimer = IframeDuration;
        RanRot = Random.Range(-5.5f, 5.5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !Iframes)
        {
            PlayerHealth -= 1;
            Debug.Log("E");
            IframeTimer = IframeDuration;
        }
    }
    void Update()
    {
        if (PlayerHealth == 1)
        {
            Debug.Log("You Lost Your $1200 SunGlassese Nooooo");
            SunGlasses.GetComponent<EnemyDieSpinn>().enabled = true;
            SunGlasses.transform.parent = null;
        }
        if (PlayerHealth == 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("\"that sounds like a skill issue\"- Mike");
        }
        if (IframeTimer > 0)
        {
         Iframes = true;
         IframeTimer -= Time.deltaTime;
        }else if (IframeTimer <= 0)
        {
            Iframes = false;
        }
    }
}
