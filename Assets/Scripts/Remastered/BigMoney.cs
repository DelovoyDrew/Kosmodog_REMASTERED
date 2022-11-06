using UnityEngine;

public class BigMoney : MonoBehaviour
{
    public static Transform Money;

    [SerializeField] private Transform _money;

    private void Awake()
    {
        Money = _money;
    }
}
