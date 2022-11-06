using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPUL : MonoBehaviour
{
    Vector3 pospul;
    void Start()
    {
        pospul = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-10 * Time.deltaTime, 0, 0);
        if (transform.position.x - pospul.x <= -20)
        {
            Destroy(this.gameObject);
        }
    }
}
