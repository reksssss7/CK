using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage {  get; private set; }

    private Vector3 _direction;
    private float _speed;
    private float _maxFlyDistance;

    private float _currentFlyDistance;

    public void Initialize(float damage, Vector3 direction, float speed,  float maxFlyDistance)
    {
        _currentFlyDistance = 0f;
        Damage = damage;
        _direction = direction;
        _speed = speed;
        _maxFlyDistance = maxFlyDistance;
    }

    private void Update()
    {
        float delta = (_speed * Time.deltaTime);
        _currentFlyDistance += delta;
        transform.Translate(_direction * delta);

        if (_currentFlyDistance >= _maxFlyDistance)
            Destroy(gameObject);
    }
}
