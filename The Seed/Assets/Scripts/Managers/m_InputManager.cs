using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_InputManager : MonoBehaviour {

    public PlayerControls pc;

    private static m_InputManager ins;

    private bool isSprintActive;

    public static m_InputManager Instance {
        get {
            return ins;
        }
    }

    private void Awake() {
        if(ins == null) {
            ins = this;
        } else {
            Destroy(this.gameObject);
        }

        pc = new PlayerControls();
    }

    private void OnEnable() {
        pc.Enable();
        pc.Player.SprintStarted.performed += x => SprintPressed();
        pc.Player.SprintFinish.performed += x => SprintReleased();
    }

    private void OnDisable() {
        pc.Disable();
    }

    private void SprintPressed() {
        isSprintActive = true;
    }

    private void SprintReleased() {
        isSprintActive = false;
    }

    public Vector2 GetMovementInput() {
        return pc.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseMovement() {
        return pc.Player.Look.ReadValue<Vector2>();
    }

    public bool GetInteractionButton() {
        return pc.Player.Interaction.triggered;
    }

    public bool GetEscapeButton() {
        return pc.Player.Pause.triggered;
    }

    public bool GetJumpButton() {
        return pc.Player.Jump.triggered;
    }
    
    public bool GetIsSprinting() {
        return isSprintActive;
    }

}
