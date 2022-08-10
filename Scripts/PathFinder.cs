using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSO _waveConfig;
    private List<Transform> _waypoints;
    private int _wayPointsIndex = 0;

    void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        _waveConfig = _enemySpawner.GetCurrentWave();
        _waypoints = _waveConfig.GetWayPoints();
        transform.position = _waypoints[_wayPointsIndex].position;
    }
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (_wayPointsIndex < _waypoints.Count)
        {
            Vector3 targetPosition = _waypoints[_wayPointsIndex].position;
            float delta = _waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                _wayPointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
