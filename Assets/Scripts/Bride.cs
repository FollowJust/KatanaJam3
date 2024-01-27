using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(MeshFilter), typeof(MeshRenderer))]
public class Bride : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10.0f;
    public float drag = 2.0f;
    private Vector3 velocity;

    private float dirtiness = 0.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 playerInput = new Vector2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
        Vector2.ClampMagnitude(playerInput, 1.0f);

        Vector3 acceleration = speed * new Vector3(playerInput.x, 0.0f, playerInput.y) - drag * velocity;
        velocity += acceleration * Time.deltaTime;
        Vector3 positionDelta = Time.deltaTime * velocity + 0.5f * Time.deltaTime * Time.deltaTime * acceleration;

        controller.Move(positionDelta);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        DirtyObject dirtyObject = hit.gameObject.GetComponent<DirtyObject>();
        if (dirtyObject != null && !dirtyObject.GetWasTriggered()) 
        {
            dirtyObject.SetWasTriggered();

            dirtiness += dirtyObject.dirtAmount;
        }
    }
}