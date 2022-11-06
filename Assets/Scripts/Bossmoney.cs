using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmoney : MonoBehaviour
{
    GameObject moon;
    public GameObject monn;
    int scet = 30;
    void Update()
    {
        if( scet == 0)
        {
            this.gameObject.SetActive(false);
        }
        if (tonk == true&&this.gameObject.activeSelf==true)
        {
            StartCoroutine("giv");
        }
    }
    bool tonk = true;
    IEnumerator giv()
    {
        scet =scet - 1;
        tonk = false;
        yield return new WaitForSeconds(0.15f);
        moon = Instantiate(monn);
        moon.transform.position = transform.position;
        tonk = true;
    }
}
