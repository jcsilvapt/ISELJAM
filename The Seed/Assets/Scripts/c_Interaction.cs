using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class c_Interaction : MonoBehaviour, IInteractable {

    public PlayableDirector controller;

    private void Awake() {
        controller = GetComponent<PlayableDirector>();
        controller.Play();
    }

    public void Interact() {
        //
    }



}
