using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieSpinn : MonoBehaviour
{
    public bool dead = false;
    [SerializeField]
    float SpinSpeed = 1;
    void Start()
    {
        
    }
    void Update()
    {
        if (dead)
        {
            Quaternion rot = transform.rotation;
            rot.z += SpinSpeed;//Time.deltaTime;
            transform.rotation = rot;
        }
    }
}
