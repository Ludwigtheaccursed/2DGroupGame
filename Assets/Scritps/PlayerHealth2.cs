using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth2 : MonoBehaviour
{
    public float PlayerHealth = 2;
    GameObject SunGlasses;
    bool Iframes = false;
    [SerializeField]
    float IframeDuration = 1;
    float IframeTimer;
    float RanRot;
    bool ran = true;
    bool ran2 = true;
    Vector3 CollidedEnemyPos;
    Vector3 SunGlassesPos;
    [SerializeField]
    float SunGlassesFlingSpeed = 10;
    //"if you want to steal my code your gonna have to give me a big fat kiss on the mouth" -Cooper :3
    void Start()
    {
        SunGlasses = GameObject.FindGameObjectWithTag("VERYCOOLSUNGLASES");
        IframeTimer = IframeDuration;
        RanRot = Random.Range(-5.5f, 5.5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !Iframes && collision.gameObject.tag != "MyDad")
        {
            PlayerHealth -= 1;
            Iframes = true;
            IframeTimer = IframeDuration;
            if (PlayerHealth == 1 && ran)
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
        if (PlayerHealth == 1 && ran)
        {
            Debug.Log("You Lost Your $1200 SunGlassese Nooooo");
            SunGlasses.GetComponent<EnemyDieSpinn>().enabled = true;
            SunGlasses.transform.parent = null;
            SunGlasses.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector3 SunGlasesFlingDir = (CollidedEnemyPos - SunGlassesPos) * 5 + new Vector3(0, Random.Range(5, 10), 0);
            SunGlasesFlingDir.Normalize();
            SunGlasses.GetComponent<Rigidbody2D>().velocity = SunGlasesFlingDir * SunGlassesFlingSpeed;
            ran = false;
        }
        if (PlayerHealth <= 0 && ran2) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("\"that sounds like a skill issue\"- Mike :3");
            ran2 = false;
        }
    }
}
