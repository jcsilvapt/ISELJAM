using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_ChestController : MonoBehaviour, IInteractable {

    [SerializeField] Transform chestTop;
    [SerializeField] Vector3 openRotation;
    [SerializeField] float speed = 1f;
    [SerializeField] bool isOpen;

    public bool open;

    private void Start() {
        if(isOpen) {
            chestTop.localRotation = Quaternion.Euler(openRotation.x, openRotation.y, openRotation.z);
        }
    }

    // Update is called once per frame
    void Update() {
        if(open) {
            chestTop.localRotation = Quaternion.Lerp(chestTop.localRotation, Quaternion.Euler(openRotation.x, openRotation.y, openRotation.z), Time.deltaTime * speed);
            if(chestTop.localEulerAngles.x > 280f && chestTop.localEulerAngles.x < 280.5f) {
                open = false;
            }
            Debug.Log(chestTop.localEulerAngles.x);
        }
    }

    public void Interact() {
        if(!isOpen) {
            isOpen = true;
            open = true;
        }
    }
}