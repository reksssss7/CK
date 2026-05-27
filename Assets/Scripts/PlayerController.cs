using UnityEngine;


public class PlayerController : BaseCharecter
{

    private PlayerInputController _playerInputController;
   
    
    protected void Awake()
    {
        base.Awake();
        _playerInputController = GetComponent<PlayerInputController>();
    }

    protected override Vector3 GetMovementDirection()
    {
        return _playerInputController.MovementDirection;
    }
}
