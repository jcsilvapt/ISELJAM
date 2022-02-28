using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_InputManager : MonoBehaviour {

    private PlayerControls pc;

    private static m_InputManager ins;

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
    }

    private void OnDisable() {
        pc.Disable();
    }

    public Vector2 GetMovementInput() {
        return pc.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseMovement() {
        return pc.Player.Look.ReadValue<Vector2>();
    }

    public bool GetInteraction() {
        return pc.Player.Interaction.triggered;
    }

    public bool GetEscapeButton() {
        return pc.Player.Pause.triggered;
    }

}
