using UnityEngine;

namespace EnemyGeneration
{
    public class MovingTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _reachThreshold = 0.1f;

        private int _currentIndex;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_waypoints == null || _waypoints.Length == 0)
                return;

            Transform targetPoint = _waypoints[_currentIndex];

            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

            Vector3 direction = targetPoint.position - transform.position;

            if (direction != Vector3.zero)
                transform.forward = direction;

            if (Vector3.Distance(transform.position, targetPoint.position) <= _reachThreshold)
                MoveToNextPoint();
        }

        private void MoveToNextPoint()
        {
            const int StepIndex = 1;

            _currentIndex = (_currentIndex + StepIndex) % _waypoints.Length;
        }
    }
}