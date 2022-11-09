using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OilTower : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;

    private LineRenderer _renderer;

    private Vector3[] _points;

    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
        _points = new Vector3[2]; 
    }

    private void Update()
    {
        _points[0] = _point1.position;
        _points[1] = _point2.position;

        _renderer.SetPositions(_points);
    }
}
