using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform _bulletSpawnPosition;

    [SerializeField]
    private Bullet _bulletPrefab;

    [SerializeField]
    private float _bulledDamage = 1f;

    [SerializeField]
    private float _bulledSpeed = 10f;

    [SerializeField]
    private float _bulletmaxFlyDistance = 10f;

    [field: SerializeField]
    public float ShootRadius { get; private set; } = 5f;

    [field: SerializeField]
    public float ShootFrequencySeconds { get; private set; } = 1f;

    public void Shoot(Vector3 targetPoint)
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.identity);
        
        var targetDirection = targetPoint - _bulletSpawnPosition.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        bullet.Initialize(_bulledDamage, targetDirection, _bulledSpeed, _bulletmaxFlyDistance);
    }
}
