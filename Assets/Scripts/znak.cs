using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class znak : MonoBehaviour
{
    public GameObject blown;
    public GameObject spe1;
    public GameObject spe2;
    public GameObject spe3;
    public GameObject spe4;
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject pla; 
     GameObject PATR;

    private OwnerBehaviour _owner;
    private Player _player;

    void Start()
    {
        _owner = FindObjectOfType<OwnerBehaviour>();
        _player = FindObjectOfType<Player>();
        PlayerPrefs.SetInt("stop", 1);
        PlayerPrefs.SetInt("partcontroll", 0);
        pla = GameObject.Find("KosmoDogWithGun");
        
        
    

    }
    public GameObject Ruscont;
    public void starttime()
    {
       
        
        buttonSTOP.SetActive(false);
        Ruscont.SetActive(false);
    }
    void Update()
    {
       
        if (GameObject.FindWithTag("part") != null)
        {
           

            if (GameObject.FindWithTag("part").activeSelf == true&&pra==true)
            {
                PlayerPrefs.SetInt("stop", 0);
                StartCoroutine("Antonkakashka");
            }
        }
        
    }
    bool pra = true;
    public GameObject buttonSTOP;
   // public GameObject camera;
    
    private IEnumerator stoptime()
    {
        yield return new WaitForSeconds(0.05f);
        buttonSTOP.SetActive(true);
        Ruscont.SetActive(true);
        //Time.timeScale = 0;
        //camera.transform.position = new Vector3(pla.transform.position.x + 4, pla.transform.position.y + 3, -50f);

    }
    private IEnumerator Antonkakashka()
    {
        pra = false;
        pla.SetActive(false);
        yield return new WaitForSeconds(1);

        


            if (HP1.activeSelf == true && HP2.activeSelf == true && HP3.activeSelf == true)
            {


                HP3.SetActive(false);
                if (PlayerPrefs.GetInt("Spawn") == 1)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                    pla.transform.position = spe1.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 2)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe2.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 3)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe3.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 0)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe4.transform.position;
                }
            }
            else if (HP1.activeSelf == true && HP2.activeSelf == true && HP3.activeSelf == false)
            {


                HP2.SetActive(false);
                if (PlayerPrefs.GetInt("Spawn") == 1)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe1.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 2)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe2.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 3)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe3.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 0)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe4.transform.position;
                }
            }
            else if (HP1.activeSelf == true && HP2.activeSelf == false && HP3.activeSelf == false)
            {


                HP1.SetActive(false);
                if (PlayerPrefs.GetInt("Spawn") == 1)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe1.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 2)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe2.transform.position;
                }
                if (PlayerPrefs.GetInt("Spawn") == 3)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe3.transform.position;
                }
                if(PlayerPrefs.GetInt("Spawn") == 0)
                {
                    pla.SetActive(true);
                blown.SetActive(false);
                pla.transform.position = spe4.transform.position;
                }
            }
        
        
        else if (HP1.activeSelf == false&& HP2.activeSelf == false && HP3.activeSelf == false)
        {
            SceneManager.LoadScene("menu");
        }
        pra = true;
        PlayerPrefs.SetInt("poolch", 0);
        StartCoroutine("stoptime");
    }
}
