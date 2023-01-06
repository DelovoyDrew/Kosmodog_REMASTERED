using System.Collections;
using UnityEngine;

public class MarsBoss : Boss
{
    [SerializeField] private MarsBossFireBall _fireballTemplate;
    [SerializeField] private Transform _fireballSpawnPoint;
    [SerializeField] private Vector3 _fireballDirection = new Vector3(-1,0,0);
    [SerializeField] private float _ballSpeed = 6;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _jumpForce = 110;
    [SerializeField] private float GroundRadius = 0.3f;
    [SerializeField] private LayerMask _wtfIsGround;

    private Rigidbody2D _rigidbody;
    private bool _grounded = false;
    private bool _isReadyToJump;


    private new void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isReadyToJump = true;

    }

    private void FixedUpdate()
    {
        CheckIsGround();
    }

    protected override int OnDamaged(int currentHp, int damage)
    {
        return currentHp - damage;
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
    }

    private void SpawnFireBall()
    {
        var ball = Instantiate(_fireballTemplate, _fireballSpawnPoint.position, Quaternion.identity);
        ball.Launch(_fireballDirection, _ballSpeed);
    }

    protected override IEnumerator StartBehaviour()
    {
        while(IsAlive) 
        {
            if (_grounded && _isReadyToJump)
            {
                StartCoroutine(Jump());
                yield return new WaitForSeconds(.1f);
                SpawnFireBall();
            }
            yield return new WaitUntil(() => _grounded);
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Jump()
    {
        _isReadyToJump = false;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.1f);
        _isReadyToJump = true;
    }

    private void CheckIsGround()
    {
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _wtfIsGround);
    }
}
