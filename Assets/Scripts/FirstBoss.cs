using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstBoss : MonoBehaviour
{

    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.3f;
    public LayerMask wtfIsGround;
    Rigidbody2D BD;
    public GameObject hpo;
    public GameObject Bighpo;
    bool chh=true;
    int hp = 50;
    float rla;
    float mra;
    void Start()
    {
        BD = GetComponent<Rigidbody2D>();
        rla = hpo.transform.localScale.x;
        mra = rla / 50;
    }
    public GameObject lines;

    void Update()
    {
        hpo.transform.localScale = new Vector3(rla, 0.314f, -1);
        if (player.transform.position.x>= 367)
        {
            Bighpo.SetActive(true);
            lines.SetActive(false);
        }
        else if(player.transform.position.x < 367)
        {
            Bighpo.SetActive(false);
            lines.SetActive(true);
        }
        if (GameObject.FindWithTag("part") != null)
        {


            //if (GameObject.FindWithTag("part").activeSelf == true )
           // {
               // hp = 30;
               // time = 1.2f;
           // }
        }
              //  Debug.Log(hp);
        if (hp == 0)
        {
            Bighpo.SetActive(false);
            StartCoroutine("die");
        }
        float yu = Random.Range(700,1000);
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, wtfIsGround);
        if (Grounded == true && chh == true)
        {
            BD.AddForce(transform.up*yu , ForceMode2D.Impulse);
            if (player.transform.position.x >= 379)
            {
                StartCoroutine("Ballspawn");
            }
          
            
        }
        if (chh == true)
        {
            StartCoroutine("TONOS");

        }
       
    }
    public GameObject ball;
    public GameObject player;
    IEnumerator die()
    {
        lines.SetActive(true);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(.1f);
        
    }
    IEnumerator TONOS()
    {
        chh = false;
        yield return new WaitForSeconds(1.5f*time);
        chh = true;

    }
    public GameObject where;
    GameObject MB;
    IEnumerator Ballspawn()
    {
        
        yield return new WaitForSeconds(.1f);
        MB = Instantiate(ball);
        MB.transform.position = where.transform.position;
        

    }
    float time=1.2f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killerpool")
        {
            hp = hp - 1;
            rla = rla - mra;
            if (hp == 40)
            {
                time = 0.9f;
            }
            if (hp == 25)
            {
                time = 0.65f;
            }
            if (hp == 10)
            {
                time = 0.5f;
            }
        }
    }

}
