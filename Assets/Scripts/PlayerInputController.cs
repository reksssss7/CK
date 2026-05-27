using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Camera _camera;
    public Vector3 MovementDirection {  get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var diraction = new Vector3(horizontal, 0f, vertical);
        diraction = _camera.transform.rotation * diraction;
        diraction.y = 0f;

        MovementDirection = diraction.normalized;
    }
}
