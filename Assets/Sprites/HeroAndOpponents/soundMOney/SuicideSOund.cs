using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideSOund : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("die");
    }
IEnumerator die()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
