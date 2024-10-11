using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlongusCube : MonoBehaviour
{
    public Material[] materials = new Material[64];
    int materialCounter = 0;
    int materialMax = 64;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (materialCounter >= materialMax - 1)
        {
            materialCounter = 0;
        }
        else {
            materialCounter++;
        }
        gameObject.GetComponent<Renderer>().material = materials[materialCounter];
    }
}
