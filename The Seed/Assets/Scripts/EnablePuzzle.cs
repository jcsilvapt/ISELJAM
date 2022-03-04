using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePuzzle : MonoBehaviour {

    [SerializeField] GameObject puzzleUI;

    private void OnTriggerEnter(Collider other) {
        /*if(other.CompareTag("Player") && !puzzleUI.GetComponent<PuzzleController>().GetIsCompleted()) {
            puzzleUI.SetActive(true);
        }*/
    }
}
