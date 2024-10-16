using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteFlip : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerFist;
    void Start()
    {
        
    }
    void Update()
    {
        float xVal = PlayerFist.transform.localPosition.x;
        xVal *= -1;
        PlayerFist.transform.localPosition = new Vector2(xVal, PlayerFist.transform.localPosition.y);
    }
}
