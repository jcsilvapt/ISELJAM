using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSequence : MonoBehaviour {

    [Header("References")]
    [SerializeField] GameObject greenCrystal;

    private void Start() {
        greenCrystal.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && SceneController.HasFinalCrystal()) {
            greenCrystal.SetActive(true);
            // Initialize Final Sequence
        }
    }

}
