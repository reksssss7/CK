using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public bool HasTarget => _target != null;
    public Vector3 TargetPosition
    {
        get
        {
            if (HasTarget)
                return _target.transform.position;
            return Vector3.zero;
        }
    }

    private Weapon _weapon;
    private float _nextShootTimerSeconds;
    private Collider[] _colliders = new Collider[2];

    private GameObject _target = null;

    private void Update()
    {
        _target = GetTarget();

        _nextShootTimerSeconds -= Time.deltaTime;
        if(_nextShootTimerSeconds <= 0)
        {
            if (HasTarget)
            {
                _weapon.Shoot(TargetPosition);
            }
            _nextShootTimerSeconds = _weapon.ShootFrequencySeconds;
        }

        
    }
    public void SetWeapon(Weapon weaponPreafab,Transform hand)
    {
        _weapon = Instantiate(weaponPreafab,hand);
        _weapon.transform.localPosition = Vector3.zero;
        _weapon.transform.localRotation = Quaternion.identity;
    }

    [SerializeField] 
    private string _targetLayerName = "Enemy";
    public void SetTargetLayer(string layerName)
    {
        _targetLayerName = layerName;
    }

    private GameObject GetTarget()
    {
        GameObject target = null;

        var position = _weapon.transform.position;
        var radius = _weapon.ShootRadius;

        var mask = LayerMask.GetMask(_targetLayerName);

        var size = Physics.OverlapSphereNonAlloc(position, radius, _colliders, mask);
        if (size > 0)
        {
            target = _colliders[0].gameObject;
        }

        return target;
    }

    private void OnDrawGizmos()
    {
        if (_weapon != null)
        {
            var lastColor = Gizmos.color;

            Gizmos.color = Color.blue;

            var position = _weapon.transform.position;
            var radius = _weapon.ShootRadius;
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.blue;
            UnityEditor.Handles.DrawWireDisc(position, Vector3.up, radius);
#endif
            Gizmos.color = lastColor;
        }
    }
}
