using System.Collections;
using UnityEngine;

public class MarsBossFireBall : MonoBehaviour
{
    [SerializeField] private float _timeTillDestroy;

    public void Launch(Vector3 direction, float speed)
    {
        StartCoroutine(Move(direction, speed));
    }

    private IEnumerator Move(Vector3 direction, float speed)
    {
        while(_timeTillDestroy > 0)
        {
            transform.position += direction * speed * Time.deltaTime;
            _timeTillDestroy -= Time.deltaTime;

            yield return null;
        }

        Destroy(this.gameObject);
    }
}
