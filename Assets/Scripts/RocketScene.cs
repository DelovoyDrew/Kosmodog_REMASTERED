using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScene : MonoBehaviour
{
    public GameObject player;
    public GameObject rocket;
    public GameObject rocketDanger;
    GameObject rok;
    GameObject rocck;
    public float fg;
    bool chek=false;
    float mytime=1;
    float random;
    private void Start()
    {
        StartCoroutine("Secondlol");
    }
    void Update()
    {

        if (player.transform.position.x >= 380)
        {
            Destroy(this.gameObject);
        }
        
        if (chek == true&&player != null)
        {
            random = Random.Range(1,3);
            if (random <= 1.1f)
            {
                fg = Random.Range(-4f,-3);
            }
             else if (random > 1.1)
            {
                fg = Random.Range(-1.21f,4);
            }
           
           
            
            StartCoroutine("Oldschool");
            StartCoroutine("Oldschol");
        }
        if (rocck != null&&player!=null)
        {
            rocck.transform.position = new Vector3(player.transform.position.x + 10, posa.y, -4.6f);
           
        }
        
    }
     Vector3 posa;
    private IEnumerator Secondlol()
    {
        yield return new WaitForSeconds(5f);
        chek = true;
    }
    private IEnumerator Oldschol()
    {
        rocck = Instantiate(rocketDanger);
        if (PlayerPrefs.GetInt("stop") == 0)
        {
            Destroy(rocck);
        }
        yield return new WaitForSeconds(0.6f);
        Destroy(rocck);
    }
        private IEnumerator Oldschool()
    {
        posa.y = player.transform.position.y;
        chek = false;
        rok = Instantiate(rocket);
        rok.transform.position = new Vector3(player.transform.position.x+35,posa.y,-4.5f);
        if (PlayerPrefs.GetInt("stop") == 0)
        {
            Destroy(rok);
        }
        yield return new WaitForSeconds(10 * mytime);
        chek = true;
    }
}
