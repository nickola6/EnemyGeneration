using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Transform _target;

    private void Update()
    {
        if (_target == null)
            return;

        MoveToTarget();
    }

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }
}