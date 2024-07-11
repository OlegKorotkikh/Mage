using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int MaxEnemyCount;
    [SerializeField] private List<UnitData> Enemies;
    [SerializeField] private List<Transform> SpawnPositions;
    [SerializeField] private UnitController EnemyPrefab;
    [SerializeField] private Fraction _fraction;
    [SerializeField] private Transform playerTransform;

    private int enemyCount;

    private void Start()
    {
        CheckEnemies();
    }

    private void CreateEnemy()
    {
        var enemy = Enemies[Random.Range(0, Enemies.Count)];
        Spawn(enemy);
        enemyCount++;
    }

    private void Spawn(UnitData enemy)
    {
        var position = GetSpawnPosition();
        var enemyObject = Instantiate(EnemyPrefab, position, Quaternion.identity);
        enemyObject.Setup(enemy, _fraction);
        enemyObject.damageable.Death += OnEnemyDeath;
        enemyObject.Target = playerTransform;
    }

    private Vector3 GetSpawnPosition()
    {
        return SpawnPositions[Random.Range(0, SpawnPositions.Count)].position;
    }

    private void OnEnemyDeath()
    {
        enemyCount--;
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        while (enemyCount < MaxEnemyCount)
        {
            CreateEnemy();            
        }
    }
}
