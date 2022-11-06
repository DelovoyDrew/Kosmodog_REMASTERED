using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [field: SerializeField] public Transform SpawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            GameManager.GameController.SetCurrnetCheckPoint(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            GameManager.GameController.SetCurrnetCheckPoint(this);
        }
    }
}
