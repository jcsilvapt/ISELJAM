using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePuzzle : MonoBehaviour {

    [SerializeField] GameObject puzzleUI;
    [SerializeField] bool isCompleted;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            puzzleUI.SetActive(true);
        }
    }
}
