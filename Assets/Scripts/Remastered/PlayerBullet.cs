using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _timeTillDestroy;
    [SerializeField] private Vector2 _direction = new Vector2 (1f, .15f);
    [SerializeField] private float _speed = 15;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(_direction * _speed, ForceMode2D.Impulse);

        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(_timeTillDestroy);
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(this.gameObject);
    }

}
