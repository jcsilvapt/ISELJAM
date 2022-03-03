using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class c_PlayerController : MonoBehaviour {

    [SerializeField, Range(0.5f, 10.0f)] float walkingSpeed = 2.0f;
    [SerializeField, Range(0.5f, 10.0f)] float runningSpeed = 5.0f;

    public Animator anim;
    public GameObject body;

    private float currentSpeed = 0f;
    private m_InputManager input;
    private Rigidbody rb;
    public Transform cameraTransform;

    private bool isRunning;

    public IInteractable interactable;

    public bool useBlendTree = false;

    private void Start() {
        input = m_InputManager.Instance;
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;

        body.transform.localRotation = Quaternion.Euler(0f, cameraTransform.localEulerAngles.y, 0f);
    }

    private void Update() {
        if (interactable != null) {
            if (input.GetInteractionButton()) {
                interactable.Interact();
            }
        }
    }

    private void FixedUpdate() {

        HandleMovement();

    }

    float lastRotation;
    float startedRotating;

    private void HandleMovement() {

        Vector2 direction = input.GetMovementInput();

        float x = direction.x;
        float z = direction.y;

        Vector3 animationMove = new Vector3(x, 0f, z);
        animationMove = animationMove.normalized;

        Vector3 movePos = cameraTransform.right * x + cameraTransform.forward * z;
        movePos = movePos.normalized;

        if (movePos != Vector3.zero) {

            if (input.GetIsSprinting()) {
                currentSpeed = runningSpeed;
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
            } else {
                currentSpeed = walkingSpeed;
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }


            Vector3 velocity = new Vector3(movePos.x, rb.velocity.y, movePos.z);
            rb.velocity = Vector3.Scale(velocity, new Vector3(currentSpeed, 1f, currentSpeed));

            lastRotation = (Mathf.Atan2(x, z) * 180) / Mathf.PI;

            Quaternion initial = body.transform.rotation;
            Quaternion target = Quaternion.Euler(0f, lastRotation + cameraTransform.localEulerAngles.y, 0f);

            if (initial != target) {
                startedRotating = Time.time;
            }
            body.transform.rotation = Quaternion.Lerp(initial, target, Time.time / (startedRotating + 10f));
        } else {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<IInteractable>() != null) {
            interactable = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<IInteractable>() != null && interactable != null) {
            interactable = null;
        }
    }

}
