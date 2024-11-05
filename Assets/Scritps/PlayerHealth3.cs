using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth3 : MonoBehaviour
{
    public float PlayerHealth = 3;
    GameObject SunGlasses;
    bool Iframes = false;
    [SerializeField]
    float IframeDuration = 1;
    float IframeTimer;
    float RanRot;
    bool Ran = true;
    bool Ran2 = true;
    bool Ran3 = true;
    Vector3 CollidedEnemyPos;
    Vector3 SunGlassesPos;
    [SerializeField]
    float SunGlassesFlingSpeed = 10;
    string EnemyTag;
    GameObject can;
    //"if you want to steal my code your gonna have to give me a big fat kiss on the mouth" -Cooper :3
    void Start()
    {
        SunGlasses = GameObject.FindGameObjectWithTag("VERYCOOLSUNGLASES");
        IframeTimer = IframeDuration;
        RanRot = Random.Range(-5.5f, 5.5f);
        can = GameObject.FindGameObjectWithTag("DeathScreen");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !Iframes && collision.gameObject.tag != "MyDad")
        {
            PlayerHealth -= 1;
            Iframes = true;
            IframeTimer = IframeDuration;
            if (PlayerHealth == 2 && Ran3)
            {
                EnemyTag = collision.gameObject.tag;
                Destroy(collision.gameObject);
            }
            if (PlayerHealth == 1 && Ran)
            {
                CollidedEnemyPos = collision.transform.position;
                SunGlassesPos = transform.position;
            }
        }
    }
    void Update()
    {
        IframeTimer -= Time.deltaTime;
        if (IframeTimer <= 0)
        {
            Iframes = false;
        }
        if (PlayerHealth == 2 && Ran3)
        {
            if (EnemyTag == "SludgeMonster")
            {
                GameObject Enemy = transform.GetChild(0).gameObject;
                Enemy.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (EnemyTag == "StreetRat")
            {
                GameObject Enemy = transform.GetChild(1).gameObject;
                Enemy.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (EnemyTag == "PreSchooler")
            {
                GameObject Enemy = transform.GetChild(2).gameObject;
                Enemy.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (EnemyTag == "Gnome")
            {
                GameObject Enemy = transform.GetChild(3).gameObject;
                Enemy.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (EnemyTag == "Vampire")
            {
                GameObject Enemy = transform.GetChild(4).gameObject;
                Enemy.GetComponent<SpriteRenderer>().enabled = true;
            }
            Debug.Log("Yooo look you got a little fren! :D");
            Ran3 = false;
        }
        if (PlayerHealth == 1 && Ran)
        {
            Debug.Log("You Lost Your $1200 SunGlassese Nooooo");
            SunGlasses.GetComponent<EnemyDieSpinn>().enabled = true;
            SunGlasses.transform.parent = null;
            SunGlasses.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector3 SunGlasesFlingDir = (CollidedEnemyPos - SunGlassesPos) * 5 + new Vector3(0, Random.Range(5, 10), 0);
            SunGlasesFlingDir.Normalize();
            SunGlasses.GetComponent<Rigidbody2D>().velocity = SunGlasesFlingDir * SunGlassesFlingSpeed;
            Ran = false;
        }
        if (PlayerHealth <= 0 && Ran2) 
        {
            can.GetComponent<Canvas>().enabled = true;
            Debug.Log("\"that sounds like a skill issue\"- Mike :3");
            Ran2 = false;
        }
    }
}
