using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable {

    [SerializeField] InteractionType type;
    [SerializeField] CrystalType cType;
    [SerializeField] bool isInteractable;
    [SerializeField, TextArea(5, 5)] string description;

    public void Interact() {
        if(isInteractable) {
            SceneController.AddInteractable(this);
            gameObject.SetActive(false);
        }
    }

    public InteractionType GetInteractionType() {
        return type;
    }

    public CrystalType GetCrystalType() {
        return cType;
    }

    public void SetInteractable(bool value) {
        this.isInteractable = value;
    }

    public bool GetInteractable() {
        return this.isInteractable;
    }

}
public enum InteractionType {
    None,
    Crystal,
    Scroll
}

public enum CrystalType {
    Red,
    Blue,
    Green,
    Yellow,
    Scroll_1,
    Scroll_2,
    Scroll_3,
    Scroll_4
}