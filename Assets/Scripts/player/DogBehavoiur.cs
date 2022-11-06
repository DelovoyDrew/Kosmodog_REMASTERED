using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogBehavoiur : MonoBehaviour
{
   
    public GameObject particles;
    Animator anim;
    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.2f;
    public LayerMask wtfIsGround;
    float Boxbusts = 1;
    float bustsc = 1;
    int jumpih=0;
    int touch=1;
    Rigidbody2D rbd;
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
    }
    
    public void AntonMuD()
    {
        if (Grounded == true)
        {
            StartCoroutine("Antonjonson");
        }

        if (jumpih < 2)
        {
            jumpih = jumpih + 1;
            if (jumpih <= 2)
            {
                rbd.velocity = Vector2.zero;
                rbd.AddForce(transform.up * 110, ForceMode2D.Impulse);
                StartCoroutine("animjp");
            }
        }
       
    }
    private IEnumerator animjp()
    {
        anim.SetInteger("blum",2);
       yield return new WaitForSeconds(.1f);
        anim.SetInteger("blum", 3);

    }
   private IEnumerator Antonjonson()
    {
        yield return new WaitForSeconds(.1f);
        jumpih = jumpih + 1;
    }

    void Update()
    {
        
        transform.Translate(7*Time.deltaTime*bustsc*Boxbusts*touch, 0, 0);
        if (transform.position.y < -8)
        {
            StartCoroutine("die");
        }
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, wtfIsGround);
        if (Grounded==true)
        {
            jumpih = 0;
        }
    }
    bool partcontrol = true;
    private IEnumerator die()
    {
        if (partcontrol == true)
        {
            PlayerPrefs.SetInt("Tryes", PlayerPrefs.GetInt("Tryes")+0);
            particles = Instantiate(particles);
            particles.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
            partcontrol =false;
            Destroy(this.gameObject);
        }
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("mars");
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pool")
        {
            StartCoroutine("die");
        }
        if (other.gameObject.tag == "boxtrig")
        {
            Boxbusts = 0.5f;
            StartCoroutine("Antonboxhalfer");
        }
        
        if (other.gameObject.tag == "platform")
        {
            touch = 0;
        }
    }
   
    


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ship")
        {
            StartCoroutine("die");
        }
        if (other.gameObject.tag == "rocket")
        {

            StartCoroutine("die");


        }

        if (other.gameObject.tag == "stop")
        {


        }
        if (other.gameObject.tag == "bust")
        {
            rbd.AddForce(transform.right * 100, ForceMode2D.Impulse);
            bustsc=1.5f;
        }
       

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "bust")
        {
           
            bustsc = 1f;
            StartCoroutine("Antonsasat");
        }
        if (other.gameObject.tag == "platform")
        {
            touch = 1;
        }

    }
    private IEnumerator Antonsasat()
    {
        yield return new WaitForSeconds(2);
        bustsc = 1;
    }
    private IEnumerator Antonboxhalfer()
    {
        yield return new WaitForSeconds(1);
        Boxbusts = 1;
    }
}
