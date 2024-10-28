using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOnPlayerFace : MonoBehaviour
{
    bool HasIsAreDoneAnSit = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (HasIsAreDoneAnSit)
        {
            HasIsAreDoneAnSit = true;
        }
    }
}
