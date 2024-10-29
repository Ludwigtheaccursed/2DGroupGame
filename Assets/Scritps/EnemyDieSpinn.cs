using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyDieSpinn : MonoBehaviour
{
    [SerializeField]
    float SpinSpeed = 1;
    float RanRot;
    void Start()
    {
        RanRot = Random.Range(-5.5f, 5.5f);
    }
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += SpinSpeed * Time.deltaTime * 30 * RanRot;
        transform.rotation = Quaternion.Euler(rot);
    }
}
