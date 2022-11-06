using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class partcontrol : MonoBehaviour
{

  
    public GameObject pla;

    private IEnumerator Antonkakashka()
    {
        PlayerPrefs.SetInt("partcontroll",1);
        pla.SetActive(false);
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("partcontroll", 0);
        Destroy(this.gameObject);
    }
        private void Start()
    {
       
       // pla = GameObject.Find("KosmoDogWithGun");
      //  StartCoroutine("Antonkakashka");
    }
}
