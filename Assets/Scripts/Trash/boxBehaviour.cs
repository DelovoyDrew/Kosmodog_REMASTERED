using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehaviour : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Antonloh");
            
        }
    }
    private IEnumerator Antonloh()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(this.gameObject);
    }
}
