using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorController : MonoBehaviour, IInteractable {

    [Header("References")]
    [SerializeField] GameObject redCrystal;
    [SerializeField] GameObject blueCrystal;
    [SerializeField] GameObject yellowCrystal;

    [Header("Developer Settings")]
    [SerializeField] int numberOfCrystalsActive = 0;
    [SerializeField] bool isOpen;

    private Animator anim;


    private void Start() {
        redCrystal.SetActive(false);
        blueCrystal.SetActive(false);
        yellowCrystal.SetActive(false);
        anim = GetComponent<Animator>();
    }
    public void Interact() {
        if(!isOpen) {
            HandleCrystalList(SceneController.GetCrystals());
        }
    }

    private void HandleCrystalList(List<Interactable> crystalList) {
        foreach(Interactable i in crystalList) {
            switch(i.GetCrystalType()) {
                case CrystalType.Red:
                    if(!redCrystal.activeSelf) {
                        redCrystal.SetActive(true);
                        numberOfCrystalsActive++;
                    }
                    break;
                case CrystalType.Blue:
                    if (!blueCrystal.activeSelf) {
                        blueCrystal.SetActive(true);
                        numberOfCrystalsActive++;
                    }
                    break;
                case CrystalType.Yellow:
                    if (!yellowCrystal.activeSelf) {
                        yellowCrystal.SetActive(true);
                        numberOfCrystalsActive++;
                    }
                    break;
            }
        }
        if(numberOfCrystalsActive == 3) {
            anim.SetTrigger("openDoor");
        }
    }

}
