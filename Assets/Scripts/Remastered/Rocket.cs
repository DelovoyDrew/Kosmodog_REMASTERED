using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public void Launch(float timeTillDestroy, float speed, Vector3 direction)
    {
        StartCoroutine(LaunchRoutine(timeTillDestroy, speed, direction));
    }

    private IEnumerator LaunchRoutine(float timeTillDestroy, float speed, Vector3 direction)
    {
        while (timeTillDestroy > 0)
        {
            timeTillDestroy -= Time.deltaTime;
            transform.position -= speed * direction * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
    
}
