using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePArticle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DIE");
    }
    IEnumerator DIE()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
    
}
