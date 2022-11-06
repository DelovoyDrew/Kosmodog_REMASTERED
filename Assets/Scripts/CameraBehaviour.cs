using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Player player;

    Vector3 pos;
    void Start()
    {
        transform.position = pos;
        pos.z = -50;
        pos.y = player.transform.position.y + 3;
        pos.x = player.transform.position.x + 4;
        transform.position = new Vector3(player.transform.position.x,0,- 50f);
    }

    bool trick = false;
    void Update()
    {

        if (trick == true)
        {
            if (player != null)
            {
                pos.z = 50;
                pos.y = 0f;
                if (player.transform.localScale == new Vector3(0.4f, 0.4f, 0.31f))
                {
                    pos.x = player.transform.position.x + 2;
                }
                if (player.transform.localScale == new Vector3(-0.4f, 0.4f, 0.31f))
                {
                    pos.x = player.transform.position.x - 2;
                }
            }
        }
        if (player != null)
        {
            pos.z = -50;
            pos.y = player.transform.position.y+1;

            pos.x = player.transform.position.x + 4;



            transform.position = Vector3.Lerp(transform.position, pos, 5f * Time.deltaTime);
            

        }
        
      

    }
}
