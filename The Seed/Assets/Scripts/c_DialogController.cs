using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class c_DialogController : MonoBehaviour {

    [Header("References")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator anim;
    [SerializeField] List<AudioClip> voiceLines;
    [SerializeField] AudioSource aSource;
    [SerializeField] GameObject redCrystal;

    [Header("Dialog Tree")]
    [TextArea(5,5)]
    [SerializeField] List<string> dialogLines;

    private int dialogId = 0;

    private void Start() {
        ChangeText();
    }

    private void OnEnable() {
        dialogId = 0;
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
        PlaySounds();
    }

    private void PlaySounds() {
        aSource.clip = voiceLines[Random.Range(0, voiceLines.Count - 1)];
        aSource.Play();
    }

    public void TakeRedCrystal() {
        Interactable crystal = redCrystal.GetComponent<Interactable>();
        crystal.Interact();
        redCrystal.SetActive(false);
    }

}
