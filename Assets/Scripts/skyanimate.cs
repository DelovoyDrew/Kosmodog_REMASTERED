using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyanimate : MonoBehaviour
{
    int napr;
    float speed;
    Vector3 startpol;
    void Start()
    {
        napr = Random.Range(0, 1);
        speed= Random.Range(3, 7);
        startpol = transform.position;
        
    }

    
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (napr == 1)
        {
            speed = 1;
        }

        if (napr == 0)
        {
            speed = -1;
        }
        if (startpol.x - transform.position.x > 3|| startpol.x - transform.position.x <- 3)
        {
            startpol = transform.position;
            //transform.localScale = new Vector3(-0.238f, .145f);
            speed = speed *- 1;
        }
    }
}
