using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable {

    [SerializeField] InteractionType type;
    [SerializeField] CrystalType cType;
    [SerializeField] bool isInteractable;

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
    Yellow
}