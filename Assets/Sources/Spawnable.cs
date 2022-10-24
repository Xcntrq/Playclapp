using UnityEngine;

public class Spawnable : MonoBehaviour, ISpawnable
{
    private float _speed;
    private float _targetDistance;
    private float _currentDistance;

    private Vector3 _deltaPosition;

    public void Init(float speed, float targetDistance)
    {
        _speed = speed;
        _targetDistance = targetDistance;
    }

    private void Start()
    {
        _currentDistance = 0f;
    }

    private void Update()
    {
        _deltaPosition = _speed * Time.deltaTime * transform.forward;
        _currentDistance += _deltaPosition.magnitude;
        transform.Translate(_deltaPosition);

        if (_currentDistance >= _targetDistance)
        {
            Destroy(gameObject);
        }
    }
}
