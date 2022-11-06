using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtag : MonoBehaviour
{
    public Collider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.tag = "platform"; 
    }

    
}
