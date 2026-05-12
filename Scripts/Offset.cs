using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 0.5f, -3f);
    [SerializeField] private float _speed = 0.25f;

    private void Update()
    {
        transform.Translate(_offset * _speed * Time.deltaTime);
    }
}
