using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class WarningRocket : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private float _offset;
    private float _yPos;

    private void Awake()
    {
        _offset = transform.position.x - _camera.position.x;
        gameObject.SetActive(false);
    }
    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 desiredPosition = transform.position;
        desiredPosition.y = _yPos;
        desiredPosition.x = _camera.position.x + _offset;

        transform.position = desiredPosition;
    }

    public void Turn(float yPos)
    {
        _yPos = yPos;

        UpdatePosition();
    }
}
