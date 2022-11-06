using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trpop : MonoBehaviour
{
    string and;
    public Text teext;
    void Awake()
    {
        //teext = GetComponent<Text>();
    }

    void Update()
    {
        and = "Попытка: " + PlayerPrefs.GetInt("Tryes");
       teext.text = (and);
    }
}
