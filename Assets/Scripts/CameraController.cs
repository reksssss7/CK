using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _followCameraoffset = Vector3.zero;
    
    [SerializeField]
    private Vector3 _rotationoffset = Vector3.zero;

    [SerializeField]
    private Transform _target;

    protected void Awake()
    {
        if (_target == null)
            throw new System.NullReferenceException("Camera target is null");
    }

    private void LateUpdate()
    {
        Vector3 targetRotation = _rotationoffset - _followCameraoffset;
        transform.position = _target.position + _followCameraoffset;
        transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
    }
}
