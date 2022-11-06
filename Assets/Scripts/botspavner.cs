using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botspavner : MonoBehaviour
{
    public GameObject player;
    public GameObject Himselfbot;

    bool tf = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (tf == true)
        {


            if (other.gameObject.tag == "Player")
            {
                Himselfbot.SetActive(true);
                //Himselfbot =Instantiate(Himselfbot);
               // Himselfbot.transform.position = new Vector2(player.transform.position.x + 30, transform.position.y + 6);
                
            }
            tf = false;
        }
    }
}
