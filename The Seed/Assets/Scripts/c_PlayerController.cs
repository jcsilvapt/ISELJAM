using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class c_PlayerController : MonoBehaviour {

    [SerializeField, Range(0.5f, 10.0f)] float walkingSpeed = 2.0f;
    [SerializeField, Range(0.5f, 10.0f)] float runningSpeed = 5.0f;

    private float currentSpeed = 0f;
    private m_InputManager input;
    private Rigidbody rb;
    public Transform cameraTransform;

    private bool isRunning;

    public IInteractable interactable;

    private void Start() {
        input = m_InputManager.Instance;
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;
    }

    private void Update() {
        if(interactable != null) {
            if(input.GetInteractionButton()) {
                interactable.Interact();
            }
        }
    }

    private void FixedUpdate() {

        HandleMovement();

    }

    private void HandleMovement() {
        Vector2 direction = input.GetMovementInput();

        float x = direction.x;
        float z = direction.y;

        Vector3 movePos = cameraTransform.right * x + cameraTransform.forward * z;
        movePos = movePos.normalized;

        if(movePos != Vector3.zero) {

            currentSpeed = input.GetIsSprinting() ? runningSpeed : walkingSpeed;

            Vector3 velocity = new Vector3(movePos.x, rb.velocity.y, movePos.z);
            rb.velocity = Vector3.Scale(velocity, new Vector3(currentSpeed, 1f, currentSpeed));
        } else {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<IInteractable>() != null) {
            interactable = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<IInteractable>() != null && interactable != null) {
            interactable = null;
        }
    }

}
