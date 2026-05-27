using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(CharacterMovementController))]
[RequireComponent(typeof(ShootingController))]


public abstract class BaseCharecter : MonoBehaviour
{

    [SerializeField]
    private Weapon _weaponPrefab;

    [SerializeField]
    private Transform _hand;

    [SerializeField]
    private float _health = 10f;


    private CharacterMovementController _characterMovementController;
    private ShootingController _shootingController;

    protected void Awake()
    {
        _characterMovementController = GetComponent<CharacterMovementController>();
        _shootingController = GetComponent<ShootingController>();
    }

    protected void Start()
    {
        _shootingController.SetWeapon(_weaponPrefab, _hand);

        if (this is PlayerController)
        {
            _shootingController.SetTargetLayer(LayerUtils.EnemyLayerName);
        }
        else if (this is EnemyController)
        {
            _shootingController.SetTargetLayer(LayerUtils.PlayerLayerName);
        }
    }
    protected void Update()
    {
        var direction = GetMovementDirection();
        var lookDirection = direction;
        if (_shootingController.HasTarget)
        {
            lookDirection = _shootingController.TargetPosition - transform.position;
            lookDirection.y = 0f;
            lookDirection.Normalize();
        }

        _characterMovementController.MovementDirection = direction;
        _characterMovementController.LookDirection = lookDirection;

        if (_health <= 0f)
            Destroy(gameObject);
    }

    protected abstract Vector3 GetMovementDirection();

    protected void OnTriggerEnter(Collider other)
    {
        if (LayerUtils.IsBullet(other.gameObject))
        {
            var bullet = other.GetComponent<Bullet>();
            _health -= bullet.Damage;
            Destroy(other.gameObject);
            
        }
    }
    protected void OnDrawGizmos()
    {
        var lastColor = Gizmos.color;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_hand.position, new Vector3(0.2f, 0.2f, 0.2f));

        Gizmos.color = lastColor;
    }

    
}
