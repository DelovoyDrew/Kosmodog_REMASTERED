using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Enemy
{
    public bool IsAlive => _hp > 0;

    [SerializeField] private int _startHp = 100;
    [SerializeField] private CustomHpController _hpUI;

    private int _hp;
    private Coroutine _activeRoutine;

    protected void Awake()
    {
        _hp = _startHp;
        _hpUI.SetHp(_hp, _startHp);
    }

    public override void TakeDamage(int damage)
    {
        _hp = OnDamaged(_hp, damage); 
        _hpUI.SetHp(_hp, _startHp);

        if(_hp <= 0)
        {
            Die();
        }
    }

    protected virtual int OnDamaged(int currentHp, int damage) { return 0; }
    protected virtual IEnumerator StartBehaviour() { yield break; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_activeRoutine == null && collision.TryGetComponent(out PlayerMovement player))
        {
            _activeRoutine = StartCoroutine(StartBehaviour());
            player.StopMovement(true);
        }
    }
}
