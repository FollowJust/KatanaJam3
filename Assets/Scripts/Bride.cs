using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

[RequireComponent(typeof(CharacterController), typeof(MeshFilter), typeof(MeshRenderer))]
public class Bride : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10.0f;
    public float drag = 2.0f;
    private Vector3 velocity;

    private float dirtiness = 0.0f;
    private float maxDirteness = 100.0f;

    private UInt64 frameID = 0;

    private bool isDead = false;
    private float timeAfterDeath = 0.0f;

    private GameObject deadMessage;

    private Vector3 forwardVector;
    private Vector3 rightVector;

    private bool hasWon = false;
    private GameObject winningMessage;

    private Animator animatorController;

    private GameObject arch;
    bool isFinishing = false;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        arch = GameObject.FindGameObjectWithTag("Arch");
        controller = GetComponent<CharacterController>();
        animatorController = GetComponentInChildren<Animator>();

        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        deadMessage = GameObject.FindGameObjectWithTag("DeadMessage");
        if (deadMessage)
        {
            deadMessage.SetActive(false);
        }

        winningMessage = GameObject.FindGameObjectWithTag("WinningMessage");
        if (winningMessage)
        {
            winningMessage.SetActive(false);
        }
    }

    void Update()
    {
        if (!isDead && !hasWon)
        {
            forwardVector = GetComponentInChildren<Camera>().transform.forward;
            forwardVector.y = 0.0f;
            forwardVector.Normalize();

            rightVector = GetComponentInChildren<Camera>().transform.right;
            rightVector.y = 0.0f;
            rightVector.Normalize();

            bool idle = true;
            bool slide = false;

            Vector2 playerInput = new Vector2(0.0f, 0.0f);
            if (Input.GetKey(KeyCode.W))
            {
                idle = false;
                playerInput.x += 1.0f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idle = false;
                playerInput.x -= 1.0f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idle = false;
                playerInput.y += 1.0f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                idle = false;
                playerInput.y -= 1.0f;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                idle = false;
                slide = true;
            }

            Vector2.ClampMagnitude(playerInput, 1.0f);

            Vector3 acceleration = speed * ((playerInput.x * forwardVector) + (playerInput.y * rightVector)) - drag * velocity;
            velocity += acceleration * Time.deltaTime;
            Vector3 positionDelta = Time.deltaTime * velocity + 0.5f * Time.deltaTime * Time.deltaTime * acceleration;

            // A stupid hack because character controller doesn't see collisions if it doesn't move. So I move it always
            positionDelta.x += (frameID % 2 == 0) ? 0.001f : -0.001f;
            frameID++;

            if (idle)
            {
                GetComponentInChildren<Animator>().Play("Idle");
            }
            else 
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionDelta), 0.3f);

                if(!animatorController.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
                {
                    string animationState = slide ? "Slide" : "Run";
                    animatorController.Play(animationState);
                }
            }

            controller.SimpleMove(velocity);

            var heading = arch.transform.position - this.transform.position;

            int maxRange = 50;
            
            if (heading.sqrMagnitude < maxRange * maxRange && !isFinishing)
            {
                GetComponent<AudioSource>().Stop();
                arch.GetComponent<AudioSource>().Play();
                isFinishing = true;
            }
        }
    }

    void LateUpdate()
    {
        if (hasWon)
        {
            if (!winningMessage.activeSelf)
            {
                winningMessage.SetActive(true);
            }
        }
        else if (dirtiness >= maxDirteness)
        {
            isDead = true;

            if (!deadMessage.activeSelf)
            {
                deadMessage.SetActive(true);
            }

            timeAfterDeath += Time.deltaTime;
            if (timeAfterDeath >= 2.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        DirtyObject dirtyObject = hit.gameObject.GetComponent<DirtyObject>();
        if (dirtyObject != null && !dirtyObject.GetWasTriggered()) 
        {
            Debug.Log($"Name {dirtyObject.name}, Dirt Amount {dirtyObject.dirtAmount}, dirtiness {dirtiness}");
            dirtyObject.SetWasTriggered();

            dirtiness += dirtyObject.dirtAmount;
            dirtiness = (dirtiness < 0.0f) ? 0.0f : dirtiness;
            if (dirtyObject.destroyAfterCollision)
            {
                Destroy(dirtyObject.gameObject);
            }
        }
        else if (hit.gameObject.tag == "Altar")
        {
            hasWon = true;
        }
    }

    // WHY THE FUCK I'M DOING THIS?
    public float GetDirtiness()
    {
        return dirtiness;
    }

    // WHY THE FUCK I'M DOING THIS?
    public float GetMaxDirtiness()
    {
        return maxDirteness;
    }
}