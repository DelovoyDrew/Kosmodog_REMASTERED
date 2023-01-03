using System.Collections;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Transform _spawnBorder;
    [SerializeField] private Rocket _rocketTemplate;
    [SerializeField] private WarningRocket _warning;

    [SerializeField] private RocketSettings _rocketSettings = new RocketSettings();

    private void Start()
    {
        StartCoroutine(StartRocketLauncher());
    }
   
    private IEnumerator StartRocketLauncher()
    {
        while(true)
        {
            yield return StartCoroutine(SpawnRocketRoutine());

            float timeTillNextLaunch = GetRandomizedFloatFromVector(_rocketSettings.PositionRandomizer);
            yield return new WaitForSeconds(timeTillNextLaunch);
        }
    }

    private float GetRandomizedFloatFromVector(Vector2 value)
    {
        value *= 10;
        return Random.Range(value.x, value.y) / 10f;
    }

    private IEnumerator SpawnRocketRoutine()
    {
        yield return new WaitUntil(() => GameManager.IsPlayerAlive);

        float speed = GetRandomizedFloatFromVector(_rocketSettings.SpeedRandomizer);
        float yPos = GameManager.PlayerInstance.transform.position.y + GetRandomizedFloatFromVector(_rocketSettings.PositionRandomizer);

        _warning.Turn(yPos);
        _warning.gameObject.SetActive(true);

        yield return new WaitForSeconds(_rocketSettings.WarningLaunchDelay);

        if(GameManager.IsPlayerAlive == false)
        {
            _warning.gameObject.SetActive(false);
            yield break;
        }

        Vector3 position = new Vector3(_spawnBorder.position.x, yPos, 0);
        Rocket rocket = Instantiate(_rocketTemplate, position, Quaternion.identity);
        rocket.Launch(_rocketSettings.TimeTillDestroy, speed, _rocketSettings.Direction);
        _warning.gameObject.SetActive(false);
    }
}

[System.Serializable]
public class RocketSettings
{
    public float WarningLaunchDelay;
    public Vector3 Direction;
    public Vector2 TimeBetweenLaunches;
    public float TimeTillDestroy;
    public Vector2 PositionRandomizer;
    public Vector2 SpeedRandomizer;
}
