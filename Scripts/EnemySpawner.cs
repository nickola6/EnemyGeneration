using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Vector3 _moveDirection = Vector3.forward;
    [SerializeField] private float _spawnDelay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (isActiveAndEnabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        const int MinValueRandom = 0;

        if (_spawnPoints.Length == 0 || _enemyPrefabs.Length == 0)
            return;

        int pointIndex = Random.Range(MinValueRandom, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[pointIndex];

        int enemyIndex = Random.Range(MinValueRandom, _enemyPrefabs.Length);
        Enemy prefab = _enemyPrefabs[enemyIndex];

        Enemy enemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        enemy.Initialize(_moveDirection);
    }
}