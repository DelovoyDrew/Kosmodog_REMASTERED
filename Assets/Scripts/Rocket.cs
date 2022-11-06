using UnityEngine;

public class Rocket : MonoBehaviour
{
    float xrast;
    private void Start()
    {
        xrast = transform.position.x;
    }
    void Update()
    {
        
        transform.position += new Vector3(-17 * Time.deltaTime, 0, 0);
        if (transform.position.x<xrast-50)
        {
            Destroy(this.gameObject);
        }
    }
    
}
