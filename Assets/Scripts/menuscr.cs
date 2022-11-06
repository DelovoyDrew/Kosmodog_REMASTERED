using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscr : MonoBehaviour
{
   
    public void Strt1()
    {
        SceneManager.LoadScene("Moon");
        PlayerPrefs.SetInt("Atmos", 1);
    }
    public void Strt2()
    {
        SceneManager.LoadScene("mars");
        PlayerPrefs.SetInt("Atmos", 2);
    }
}
