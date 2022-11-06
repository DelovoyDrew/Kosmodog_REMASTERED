using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 25;

    private Transform bigmoney;

    private void Start()
    {
        bigmoney = BigMoney.Money;
    }

    
    private IEnumerator Picked()
    {
        while(Vector2.Distance(transform.position, bigmoney.position) > .2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, bigmoney.position, _speed * Time.deltaTime);
            yield return null;
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player dog))
        {
            StartCoroutine(Picked());
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        }
       
    }
}
