using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 startDirectionToPlayer = Vector3.zero;
    private float rotation = 0.0f;
    public float mouseSens = 200.0f;
    public float arrowSens = 30.0f;
    void Start()
    {
        startDirectionToPlayer = transform.position - player.position;
    }

    void LateUpdate()
    {
        float arrowInput = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            arrowInput -= 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            arrowInput += 1.0f;
        }

        if (arrowInput != 0.0f)
        {
            rotation += arrowInput * arrowSens * Time.deltaTime;
        }
        else
        {
            rotation += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        }

        Quaternion quatRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        transform.position = player.position + quatRotation * startDirectionToPlayer;

        transform.LookAt(player.position);
    }
}
