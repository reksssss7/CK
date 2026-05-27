using UnityEngine;

public class EnemyController : BaseCharecter
{
    protected override Vector3 GetMovementDirection()
    {
        return Vector3.forward;
    }
}
