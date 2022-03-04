using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public static SceneController ins;

    [Header("InGame References")]
    [SerializeField] List<Interactable> crystalList;
    [SerializeField] List<Interactable> messagesList;

    [Header("Developer Settings")]
    [SerializeField] bool hasAllCrystals;
    [SerializeField] bool hasFinalCrystal;
    [SerializeField] bool hasAllMessages;

    [SerializeField] int numberOfCrystals = 3;
    [SerializeField] int numberOfMessages = 4;

    private void Awake() {
        if(ins == null) {
            ins = this;
        }
    }
    
    private void HandleAddition(Interactable interactable) {
        switch (interactable.GetInteractionType()) {
            case InteractionType.Crystal:
                crystalList.Add(interactable);
                if (crystalList.Count == numberOfCrystals) hasAllCrystals = true;
                break;
            case InteractionType.Scroll:
                messagesList.Add(interactable);
                if (messagesList.Count == numberOfMessages) hasAllMessages = true;
                break;
        }
    }

    public static void AddInteractable(Interactable interactable) {
        if(ins != null) {
            ins.HandleAddition(interactable);
        }
    }

    public static List<Interactable> GetCrystals() {
        if(ins != null) {
            return ins.crystalList;
        }
        return null;
    }
    public static List<Interactable> GetMessages() {
        if (ins != null) {
            return ins.messagesList;
        }
        return null;
    }
}
