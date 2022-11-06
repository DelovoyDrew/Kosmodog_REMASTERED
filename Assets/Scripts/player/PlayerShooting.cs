using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Blown _blownEffect;
    [SerializeField] private float _shootingDelay;

    private bool _canShoot;

    private void Awake()
    {
        _canShoot = true;
    }

    public void TryShoot()
    {
        if (!_canShoot) return;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        StartCoroutine(PlayBlownEffect());
        yield return new WaitForSeconds(_shootingDelay);
        _canShoot = true;
    }

    private IEnumerator PlayBlownEffect()
    {
        _blownEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        _blownEffect.gameObject.SetActive(false);
    }
}
