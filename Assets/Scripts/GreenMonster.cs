using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : DontTouchingEnemy
{
    public GameObject particles;

    protected override void Die()
    {
        particles = Instantiate(particles);
        particles.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Destroy(this.gameObject);
    }
}
