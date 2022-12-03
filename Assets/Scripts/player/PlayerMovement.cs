using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _isThereObstacle;
    [SerializeField] private GameObject _shadow;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _bodyTransform;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 110;
    [SerializeField] private int _doubleJumpCount = 2;
    [SerializeField] private float GroundRadius = 0.3f;
    [SerializeField] private float _distanceToStopInFrontObstacle = .05f;
    [SerializeField] private LayerMask _wtfIsGround;

    private Rigidbody2D _rigidbody;

    private OwnerBehaviour _owner;

    private bool _grounded = false;
    private int _jumpsCount;
    private bool _isReadyToJump;
    private bool _canMove;

    private string _jumpAnimation = "Jump";
    private string _runAnimation = "Run";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _owner = FindObjectOfType<OwnerBehaviour>();

        _canMove = true;
        _isReadyToJump = true;
        _jumpsCount = 0;
    }

    private void Update()
    {
        TryMove();
    }

    private void FixedUpdate()
    {
        CheckIsGround();
    }


    public void ResetMovement()
    {
        StopMovement(true);
        StopAllCoroutines();
        _animator.SetBool(_jumpAnimation, false);
        _animator.SetBool(_runAnimation, true);
        _rigidbody.velocity = Vector2.zero;
        _isReadyToJump = true;
    }

    public void TryJump()
    {
        if(_jumpsCount < _doubleJumpCount && _isReadyToJump)
        {
            StartCoroutine(Jump());
            _jumpsCount++;
        }
    }

    public void StopMovement(bool isStoped)
    {
        _canMove = !isStoped;
        _animator.SetBool(_runAnimation, isStoped);
    }

    private void TryMove()
    {
        Ray2D ray = new Ray2D(new Vector2(_isThereObstacle.transform.position.x, 0),  transform.right);
        RaycastHit2D hit = Physics2D.Raycast(_isThereObstacle.position, ray.direction, _distanceToStopInFrontObstacle);

        if (hit.collider != null && hit.collider.tag == "Obstacle")
        {
            if (_owner.gameObject.activeSelf == false) _owner.TryAppear(transform.position);
            else _owner.StartChasing();
            return;
        }
        int canMove = _canMove ? 1 : 0;
        transform.position += Vector3.right * _speed * canMove * Time.deltaTime;
    }

    private IEnumerator Jump()
    {
        _isReadyToJump = false;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        StartCoroutine(JumpAnimation());

        yield return new WaitForSeconds(0.1f);
        _isReadyToJump = true;
    }

    private IEnumerator JumpAnimation()
    {
        _animator.SetBool(_runAnimation, false);
        _animator.SetBool(_jumpAnimation, true);
        yield return new WaitUntil(() => _grounded);
        _animator.SetBool(_jumpAnimation, false);
        _animator.SetBool(_runAnimation, true);


    }

    private void CheckIsGround()
    {
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _wtfIsGround);
        _shadow.SetActive(_grounded);

        if (_grounded == true) _jumpsCount = 0;
    }

}
