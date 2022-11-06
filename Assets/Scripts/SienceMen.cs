using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SienceMen : MonoBehaviour
{
    public GameObject blown;
    bool partcontroll = true;
    public GameObject particles;
    public GameObject player;
    public GameObject stvol;
    public GameObject pool;
    float mmm=1;
    public LayerMask wtfIsGround;
    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.2f;
    Rigidbody2D rcd;
    void Start()
    {
       
        rcd = GetComponent<Rigidbody2D>();
    }
    IEnumerator prank()
    {
        blown.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        blown.SetActive(false);
    }
    IEnumerator die()
    {
       
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
    void Update()
    {
        if ( this.gameObject.activeSelf == true)
        { 
        if (PlayerPrefs.GetInt("partcontroll")== 1)
            {
                StartCoroutine("die");
            }
         }
        player =GameObject.FindWithTag("Player");
        transform.Translate(-2 * Time.deltaTime*mmm, 0, 0);
        RaycastHit2D hit;
        Ray2D ray = new Ray2D(new Vector2(transform.position.x, transform.position.y - 0.3f), -1*transform.right);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.3f), ray.direction * 1.4f);
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.3f), ray.direction *1.4f);
       
        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.name == "myground" && Grounded == true && hit.distance <= 1.4f)
            {

                rcd.velocity = Vector2.zero;
                rcd.AddForce(transform.up * 120, ForceMode2D.Impulse);


            }
        }
            
        if(hit.distance <= 1.4f)
        {
            mmm = 2;
        }
        else
        {
            mmm = 1;
        }
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, wtfIsGround);
        if (player != null)
        {
            if (transform.position.x - player.transform.position.x <= 6 && transform.position.y - player.transform.position.y <= 0.5 && transform.position.y - player.transform.position.y >= -0.5)
            {
                if (poolchm == true)
                {
                    StartCoroutine("schwtchif");
                }
                   
                
            }
        }
        



    }
    GameObject poUl;
    bool poolch=false;
    bool poolchm = true;
    IEnumerator schwtchif()
    {
        poolchm = false;
        poolch = false;
        yield return new WaitForSeconds(.35f);
        poolch = true;
        StartCoroutine("shooting");
    }
    IEnumerator shooting()
    {
        
        if (poolch == true)
        {
            StartCoroutine("prank");
            poUl = Instantiate(pool);
            poolch = false;
            poUl.transform.position = new Vector3(stvol.transform.position.x, stvol.transform.position.y, transform.position.z);
        }
       
        yield return new WaitForSeconds(0.5f);
       // StartCoroutine("schwtchif");
        poolchm = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killerpool")
        {
            StartCoroutine("smert");
        }
    }
    private IEnumerator smert()
    {
        if (partcontroll == true)
        {
            particles = Instantiate(particles);
            particles.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            partcontroll = false;
            transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y + 2, -7.9f);
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(1);
    }
}
