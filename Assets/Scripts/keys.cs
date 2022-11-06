using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keys : MonoBehaviour
{
   
    void Start()
    {
        if (!PlayerPrefs.HasKey("Tryes"))
        {
            PlayerPrefs.SetInt("Tryes", 0);
        }
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
        }
        if (!PlayerPrefs.HasKey("Atmos"))
        {
            PlayerPrefs.SetInt("Atmos",1);
        }
        if (!PlayerPrefs.HasKey("Spawn") || PlayerPrefs.HasKey("Spawn"))
        {
            PlayerPrefs.SetInt("Spawn", 0);

        }
        if (!PlayerPrefs.HasKey("partcontroll") || PlayerPrefs.HasKey("partcontroll"))
        {
            PlayerPrefs.SetInt("partcontroll", 0);
        }
        if (!PlayerPrefs.HasKey("poolch") || PlayerPrefs.HasKey("poolch"))
        {
            PlayerPrefs.SetInt("poolch", 0);
        }
        if (!PlayerPrefs.HasKey("stop") || PlayerPrefs.HasKey("stop"))
        {
            PlayerPrefs.SetInt("stop", 1);
        }
    }

    
    
}
