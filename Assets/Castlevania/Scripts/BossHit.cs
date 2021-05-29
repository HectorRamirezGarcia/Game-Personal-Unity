using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    public GameObject objToDestroy;
 
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "Player" )
     {
         Destroy(other.gameObject);
     }
 
    }
}
