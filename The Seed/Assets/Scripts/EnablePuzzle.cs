using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePuzzle : MonoBehaviour, IInteractable {

    [SerializeField] GameObject puzzleUI;
    [SerializeField] PuzzleController currentPuzzle;
    [SerializeField] Animator anim;

    public void OpenDoors() {
        anim.SetTrigger("openDoor");
        puzzleUI.SetActive(false);
    }

    public void Interact() {
        puzzleUI.SetActive(true);
        if (currentPuzzle.GetIsCompleted()) {
            puzzleUI.SetActive(false);
        } else {
            currentPuzzle.SetController(this);
        }
    }
}
