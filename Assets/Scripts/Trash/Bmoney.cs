using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bmoney : MonoBehaviour
{
    GameObject Bigmoney;
    Rigidbody2D rb;
    void Start()
    {
        Bigmoney = GameObject.FindWithTag("BigMoney");
        rb = GetComponent<Rigidbody2D>();
        float z = Random.Range(1,3);
        float y = Random.Range(-2,2);
        rb.AddForce(new Vector2(y, z) * 7f, ForceMode2D.Impulse);
    }
    bool gnil = false;
    void Update()
    {
        if (gnil == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Bigmoney.transform.position, 25 * Time.deltaTime);
        }
        if (transform.position.y - Bigmoney.transform.position.y > -0.2 && transform.position.y - Bigmoney.transform.position.y < 0.2 && transform.position.x - Bigmoney.transform.position.x > -0.2 && transform.position.x - Bigmoney.transform.position.x < 0.2)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);

        }
    }

    IEnumerator boom()
    {
        yield return new WaitForSeconds(0.5f);
        gnil = true;
    }
}
