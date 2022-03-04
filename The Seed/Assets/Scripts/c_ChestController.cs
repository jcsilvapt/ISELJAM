using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_ChestController : MonoBehaviour, IInteractable {

    [SerializeField] Transform chestTop;
    [SerializeField] Vector3 openRotation;
    [SerializeField] float speed = 1f;
    [SerializeField] bool isOpen;
    [SerializeField] GameObject crystalPrefab;

    private Interactable crystal;

    public bool open;
    public bool isFullyOpen = false;

    private void Start() {
        if(isOpen) {
            chestTop.localRotation = Quaternion.Euler(openRotation.x, openRotation.y, openRotation.z);
        }
        crystal = crystalPrefab.GetComponent<Interactable>();
        crystal.SetInteractable(false);

    }

    // Update is called once per frame
    void Update() {
        if(open) {
            chestTop.localRotation = Quaternion.Lerp(chestTop.localRotation, Quaternion.Euler(openRotation.x, openRotation.y, openRotation.z), Time.deltaTime * speed);
            if(chestTop.localEulerAngles.x > 280f && chestTop.localEulerAngles.x < 280.5f) {
                open = false;
                isFullyOpen = true;
            }
        }
        if(isFullyOpen) {
            crystal.SetInteractable(true);
            crystal.Interact();
        }
    }

    public void Interact() {
        if(!isOpen) {
            isOpen = true;
            open = true;
        }
    }

}