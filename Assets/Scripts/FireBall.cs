using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rd;
    private void Start()
    {
        player= GameObject.FindWithTag("Player");
        StartCoroutine("die");
    }
    void Update()
    {
        transform.Translate(-6* Time.deltaTime, 0, 0);
        if (player.transform.position.x > 380.5)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
}
