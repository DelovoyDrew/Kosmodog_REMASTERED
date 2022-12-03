using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static Player PlayerInstance;

    public static bool IsPlayerAlive;

    [SerializeField] private List<BoneHP> _boneHPs;
    [SerializeField] private GameObject _continueInterface;

    public static GameManager GameController;

    private CheckPoint _currentCheckPoint;
    private OwnerBehaviour _owner;

    private void Awake()
    {
        PlayerInstance = FindObjectOfType<Player>();
        _owner = FindObjectOfType<OwnerBehaviour>();
        IsPlayerAlive = true;
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

    public bool TryToRevivePlayer()
    {
        if (_boneHPs.Count > 0)
        {
            var hp = _boneHPs[_boneHPs.Count - 1];
            hp.gameObject.SetActive(false);
            _boneHPs.Remove(hp);

            PlayerInstance.Revive(_currentCheckPoint.SpawnPoint.position);

            _continueInterface.SetActive(true);
            return true;
        }
        return false;
    }

    public void ContinueGame()
    {
        if (_boneHPs.Count == 0) return;
        IsPlayerAlive = true;
        _owner.CanAppear = true;
        PlayerInstance.StartMovement();
        _continueInterface.SetActive(false);
        // _owner.TryAppear(_player.transform.position);
    }
}
