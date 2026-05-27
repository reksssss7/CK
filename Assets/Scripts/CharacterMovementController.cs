using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMovementController : MonoBehaviour
{
    
    [SerializeField, Range(0f,10f)]
    private float _speed = 1f;

    [SerializeField, Range(0f, 45f)]
    private float _rotationspeed = 1f;

    public Vector3 MovementDirection { get; set; }
    public Vector3 LookDirection { get; set; }

    private CharacterController _characterController;
    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
          
    }

    
    private void Update()
    {
        Translate();
        Rotate();
    }
    private void Translate()
    {
        if (MovementDirection != Vector3.zero)
        {
            var delta = MovementDirection * (_speed * Time.deltaTime);
            _characterController.Move(delta);
        }
    }

    private void Rotate()
    {
        if (LookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(LookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationspeed * Time.deltaTime);
        }
    }
}
