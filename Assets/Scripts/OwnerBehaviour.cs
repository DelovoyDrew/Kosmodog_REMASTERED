using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerBehaviour : DontTouchingEnemy
{
    [SerializeField] private List<Transform> _stopPoints;

    public GameObject player;
    public LayerMask wtfIsGround;
    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.2f;
    Rigidbody2D rcd;

    public bool isCanChangeSpeed => _speedChanging == null;
    private Coroutine _speedChanging;

    public bool CanAppear;

    void Start()
    {
        rcd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            if (transform.position.y < -8)
            {
                this.gameObject.SetActive(false);
                speed = 9f;
            }
            if (player.transform.position.x - transform.position.x >=8|| transform.position.x - player.transform.position.x >=8)
            {
                this.gameObject.SetActive(false);
                speed = 9f;
            }

            foreach (var point in _stopPoints)
            {
                if(Mathf.Abs(transform.position.x - point.position.x) <.1f)
                {
                    StartCoroutine(SmoothlyChangeSpeed(3));
                }
            }

            Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, wtfIsGround);

            RaycastHit2D hit;
            Ray2D ray = new Ray2D(new Vector2(transform.position.x, transform.position.y - 0.7f), 1 * transform.right);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.7f), ray.direction * 1.4f);
            hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.7f), ray.direction * 1.4f);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "myground" && Grounded == true && hit.distance <= 1.4f)
                {

                    rcd.velocity = Vector2.zero;
                    rcd.AddForce(transform.up * 120, ForceMode2D.Impulse);
                }
            }

            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    float  speed =9f;

    public void TryAppear(Vector3 playerPosition)
    {
        if (!CanAppear) return;

        transform.position = playerPosition + new Vector3(-7.8f, 4, 0);
        speed = 10;
        gameObject.SetActive(true);

        StartCoroutine(SmoothlyChangeSpeed(9));
        StartCoroutine(SmoothlyChangeSpeed(4, 2));
    }

    public void StartChangingSpeed(float targetSpeed, float time = 0)
    {
        if (!isCanChangeSpeed) StopCoroutine(_speedChanging);

        _speedChanging = null;
        _speedChanging = StartCoroutine(SmoothlyChangeSpeed(targetSpeed, time));
    }

    private IEnumerator SmoothlyChangeSpeed(float targetSpeed, float time = 0)
    {
        yield return new WaitForSeconds(time);

        while(Mathf.Abs(speed-targetSpeed) >.01f)
        {
            speed = Mathf.Lerp(speed, targetSpeed, 0.6f * Time.deltaTime);
            yield return null;
        }
    }

}
