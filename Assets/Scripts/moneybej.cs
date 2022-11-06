using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneybej : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0, -100 * Time.deltaTime, 0);
    }
}
