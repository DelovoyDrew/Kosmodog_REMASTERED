using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerBehaviour : DontTouchingEnemy
{
    [SerializeField] private List<Transform> _stopPoints;
    [SerializeField] private Transform _obstacleChecker;
    [SerializeField] private float _distanceToStopInFrontObstacle;
    [SerializeField] private float _jumpForce;
    [SerializeField] private OwnerMovementSettings _speeds = new OwnerMovementSettings();

    public GameObject player;
    public LayerMask wtfIsGround;
    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.2f;
    Rigidbody2D rcd;

    private Coroutine _speedChanging;
    private OwnerMovementSettings.CurrentSpeedType _currentSpeedType;
    private float _currentSpeed;


    public bool CanAppear;

    void Start()
    {
        _currentSpeedType = OwnerMovementSettings.CurrentSpeedType.Normal;
        _currentSpeed = _speeds.GetSpeed(_currentSpeedType);
        rcd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            if (transform.position.y < -8)
            {
                Disappear();
            }
            if (player.transform.position.x - transform.position.x >=10|| transform.position.x - player.transform.position.x >=10)
            {
                Disappear();
            }

            foreach (var point in _stopPoints)
            {
                if(Mathf.Abs(transform.position.x - point.position.x) <.1f)
                {
                    StartCoroutine(StartChangingSpeed(OwnerMovementSettings.CurrentSpeedType.Stop));
                    break;
                }
            }

            Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, wtfIsGround);
            transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        Ray2D ray = new Ray2D(new Vector2(_obstacleChecker.transform.position.x, 0), transform.right);
        RaycastHit2D hit = Physics2D.Raycast(_obstacleChecker.position, ray.direction, _distanceToStopInFrontObstacle);

        if (hit.collider != null && hit.collider.tag == "Obstacle" && Grounded)
        {
            rcd.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

        }
    }

    public void Disappear()
    {
        StopAllCoroutines();
        _currentSpeedType = OwnerMovementSettings.CurrentSpeedType.Chasing;
        gameObject.SetActive(false);
    }

    public void TryAppear(Vector3 playerPosition)
    {
        if (!CanAppear) return;

        transform.position = playerPosition + new Vector3(-7.8f, 4, 0);

        gameObject.SetActive(true);

        StartChasing();
    }

    public void StartChasing()
    {
        StartCoroutine(StartChangingSpeed(OwnerMovementSettings.CurrentSpeedType.Chasing));
        StartCoroutine(StartChangingSpeed(OwnerMovementSettings.CurrentSpeedType.Normal, _speeds.ReturnToNormalSpeedDelay));
        StartCoroutine(StartChangingSpeed(OwnerMovementSettings.CurrentSpeedType.Slow, _speeds.ReturnToSlowSpeedDelay));
    }

    public IEnumerator StartChangingSpeed(OwnerMovementSettings.CurrentSpeedType type, float time = 0)
    {
        yield return new WaitForSeconds(time);

        if (_currentSpeedType == OwnerMovementSettings.CurrentSpeedType.Stop) yield break;
        if (_speedChanging != null) StopCoroutine(_speedChanging);

        _currentSpeedType = type;

        _speedChanging = StartCoroutine(SmoothlyChangeSpeed(_speeds.GetSpeed(_currentSpeedType)));
    }

    private IEnumerator SmoothlyChangeSpeed(float targetSpeed)
    {
        while(Mathf.Abs(_currentSpeed - targetSpeed) >.01f)
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, _speeds.SmoothChangingSpeedValue * Time.deltaTime);
            yield return null;
        }
    }

}

[System.Serializable]
public class OwnerMovementSettings
{
    [SerializeField] private float NormalSpeed;
    [SerializeField] private float ChasingSpeed;
    [SerializeField] private float SlowDownSpeed;
    [SerializeField] private float StopSpeed;

    public float ReturnToNormalSpeedDelay;
    public float ReturnToSlowSpeedDelay;

    public float SmoothChangingSpeedValue = 0.6f;

    public enum CurrentSpeedType
    {
        Normal,
        Chasing,
        Slow,
        Stop
    }

    public float GetSpeed(CurrentSpeedType type)
    {
        switch(type)
        {
            case CurrentSpeedType.Normal:
                return NormalSpeed;
            case CurrentSpeedType.Chasing: 
                return ChasingSpeed;
            case CurrentSpeedType.Slow:
                return SlowDownSpeed;
            case CurrentSpeedType.Stop:
                return StopSpeed;
        }

        throw new System.Exception("Not Supported type");
    }
}
