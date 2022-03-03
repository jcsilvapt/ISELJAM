using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class c_DialogController : MonoBehaviour {

    [Header("References")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator anim;

    [Header("Dialog Tree")]
    [TextArea(5,5)]
    [SerializeField] List<string> dialogLines;

    private int dialogId = 0;

    private void Start() {
        ChangeText();
    }

    private void ChangeText() {
        text.SetText(dialogLines[dialogId]);
    }

    public void ShowNextText() {
        if(dialogId <= dialogLines.Count) {
            dialogId++;
        }

        ChangeText();
    }

    public void TalkAnimation() {
        anim.SetTrigger("talk");
    }

}
