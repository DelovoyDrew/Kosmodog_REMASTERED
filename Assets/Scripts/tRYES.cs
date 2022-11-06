using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tRYES : MonoBehaviour
{
    
    void Start()
    {
        
        StartCoroutine("Lady");
    }
    public GameObject HPclass1;
    public GameObject HPclass2;
    public GameObject HPclass3;

    IEnumerator Lady()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        HPclass1.transform.position=new Vector3(HPclass1.transform.position.x, HPclass1.transform.position.y, -10);
        HPclass2.transform.position = new Vector3(HPclass2.transform.position.x, HPclass2.transform.position.y, -10);
        HPclass3.transform.position = new Vector3(HPclass3.transform.position.x, HPclass3.transform.position.y, -10);


    }
}
