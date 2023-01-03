using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHpController : MonoBehaviour
{
    [SerializeField] private Image _hpImage;
    [SerializeField] private RectTransform _hpMask;

    [SerializeField] private float _offsetForTime;

    private Vector3 _maskStartPosition;

    private void Awake()
    {
        _maskStartPosition = _hpMask.localPosition;
    }

    public void SetHp(int hp, int maxHp)
    {
        if (hp > 0)
        {
            float uiHp = (float)hp / (maxHp-8);
            _hpImage.fillAmount = uiHp;
            Vector3 desiredPosition = _maskStartPosition;
            desiredPosition.x -= _offsetForTime * (maxHp - hp);
            _hpMask.localPosition = desiredPosition;
        }
        else
        {
            _hpImage.fillAmount = 0;
        }
    }
}
