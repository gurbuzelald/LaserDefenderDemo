using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu (menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> _enemyPrefabs;
    [SerializeField] Transform _pathPrefab;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _timeBetweenEnemySpawns = 1f;
    [SerializeField] float _spawnTimeVariance = 0f;
    [SerializeField] float _minSpawnTime = 0.2f;


    public int GetEnemyCount()
    {
        return _enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return _enemyPrefabs[index];
    }

    public Transform GetStartingWayPoints()
    {
        return _pathPrefab.GetChild(0);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in _pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(_timeBetweenEnemySpawns - _spawnTimeVariance, 
                                       _timeBetweenEnemySpawns + _spawnTimeVariance);

        return Mathf.Clamp(spawnTime, _minSpawnTime, float.MaxValue);
    }
}
