using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelete : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 4);
    }
}
