using System.Collections;
using UnityEngine;

namespace EnemyGeneration
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private float _delay = 5f;

        private WaitForSeconds _wait;

        private void Start()
        {
            _wait = new WaitForSeconds(_delay);

            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (isActiveAndEnabled)
            {
                Spawn();

                yield return _wait;
            }
        }

        private void Spawn()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.Initialize(_target);
        }
    }
}