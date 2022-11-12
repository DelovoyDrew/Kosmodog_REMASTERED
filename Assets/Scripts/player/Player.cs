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
        PlayerPrefs.SetInt("partcontroll", 0);
        _owner = FindObjectOfType<OwnerBehaviour>();
        _movement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            StartCoroutine("die");
        }
    }

    public void Revive(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        _movement.StopMovement(false);
    }

    public void Shootg()
    {
        _shooting.TryShoot();
    }

    
    public GameObject Owner;
   
    bool lol = false;
    public GameObject Boss;
    public GameObject buttonSTOP;


    public void starttime()
    {
        buttonSTOP.SetActive(false);
    }
   
    public void StartMovement()
    {
        _movement.StopMovement(false);
    }
   
    private IEnumerator die()
    {
        yield return new WaitForSeconds(.05f);

        _dieParticles.Play();
        _movement.StopMovement(true);

        _owner.CanAppear = false;
        _owner.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameManager.GameController.TryToRevivePlayer();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out DontTouchingEnemy enemy))
        {
            StartCoroutine(die());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out DontTouchingEnemy enemy))
        {
            StartCoroutine(die());
        }
    }
}


