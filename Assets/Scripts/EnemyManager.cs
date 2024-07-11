using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private List<UnitData> _enemies;
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private UnitController _enemyPrefab;
    [SerializeField] private Fraction _fraction;
    [SerializeField] private Transform _playerTransform;

    private int enemyCount;

    private void Start()
    {
        CheckEnemies();
    }

    private void CreateEnemy()
    {
        var enemy = _enemies[Random.Range(0, _enemies.Count)];
        Spawn(enemy);
        enemyCount++;
    }

    private void Spawn(UnitData enemy)
    {
        var position = GetSpawnPosition();
        var enemyObject = Instantiate(_enemyPrefab, position, Quaternion.identity);
        enemyObject.Setup(enemy, _fraction);
        enemyObject.Damageable.Death += OnEnemyDeath;
        enemyObject.Target = _playerTransform;
    }

    private Vector3 GetSpawnPosition()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)].position;
    }

    private void OnEnemyDeath()
    {
        enemyCount--;
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        while (enemyCount < _maxEnemyCount)
        {
            CreateEnemy();            
        }
    }
}
