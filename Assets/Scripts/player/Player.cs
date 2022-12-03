using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem _dieParticles;

    private PlayerMovement _movement;
    private PlayerShooting _shooting;
    private OwnerBehaviour _owner;

    private void Start()
    {
        _owner = FindObjectOfType<OwnerBehaviour>();
        _movement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            StartCoroutine(Die());
        }
    }

    public void Revive(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Shootg()
    {
        _shooting.TryShoot();
    }
    
    public void StartMovement()
    {
        _movement.StopMovement(false);
    }
   
    private IEnumerator Die()
    {
        GameManager.IsPlayerAlive = false;

        yield return new WaitForSeconds(.11f);

        _movement.ResetMovement();
        _shooting.ResetShooting();

        _dieParticles.Play();

        _owner.CanAppear = false;
        _owner.gameObject.SetActive(false);
        _owner.CanAppear = true;
        gameObject.SetActive(false);

        _movement.StopMovement(true);
        if(GameManager.GameController.TryToRevivePlayer())
        {
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out DontTouchingEnemy enemy))
        {
            StartCoroutine(Die());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out DontTouchingEnemy enemy))
        {
            StartCoroutine(Die());
        }
    }
}


