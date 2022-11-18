using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<BoneHP> _boneHPs;
    [SerializeField] private GameObject _continueInterface;

    public static GameManager GameController;

    private CheckPoint _currentCheckPoint;
    private Player _player;
    private OwnerBehaviour _owner;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _owner = FindObjectOfType<OwnerBehaviour>();
    }

    private void Start()
    {
        if (GameController == null) GameController = this;
        else Destroy(gameObject);
    }

    public void SetCurrnetCheckPoint(CheckPoint point)
    {
        _currentCheckPoint = point;
    }

    public void TryToRevivePlayer()
    {
        if(_boneHPs.Count > 0)
        {
            var hp = _boneHPs[_boneHPs.Count - 1];
            hp.gameObject.SetActive(false);
            _boneHPs.Remove(hp);

            _player.Revive(_currentCheckPoint.SpawnPoint.position);

            _continueInterface.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        if (_boneHPs.Count == 0) return;

        _owner.CanAppear = true;
        _player.StartMovement();
        _continueInterface.SetActive(false);
        // _owner.TryAppear(_player.transform.position);
    }
}
