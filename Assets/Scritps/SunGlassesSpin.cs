using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunGlassesSpin : MonoBehaviour
{
    [SerializeField]
    float SpinSpeed = 5;
    float RanRot;
    void Start()
    {
        RanRot = Random.Range(5f, 15f);
    }
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += SpinSpeed * Time.deltaTime * 30 * RanRot;
        transform.rotation = Quaternion.Euler(rot);
    }
}
