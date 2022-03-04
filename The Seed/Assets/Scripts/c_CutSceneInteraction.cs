using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

[RequireComponent(typeof(PlayableDirector))]
public class c_CutSceneInteraction : MonoBehaviour, IInteractable {

    [Header("References")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator anim;
    [SerializeField] c_StoreWarning store;
    [SerializeField] List<AudioClip> voiceLines;
    [SerializeField] AudioSource aSource;

    [Header("Stages & Dialogs")]
    [SerializeField] List<CutScenePhase> stage; 

    private PlayableDirector director;
    private int stageId = 0;
    private string currentText;

    private void Awake() {
        director = GetComponent<PlayableDirector>();
    }

    private void ChangeText() {
        text.SetText(currentText);
    }
    
    private void NextStage() {
        if(stageId < stage.Count) {
            stageId++;
        }
        if(stageId >= 1) {
            store.NextDialog();
        }
    }

    public void NextStageDialog() {

        anim.SetTrigger("isTalking");
        PlaySounds();

        if (stage[stageId].dialogId < stage[stageId].dialog.Count) {
            stage[stageId].dialogId++;
            currentText = stage[stageId].dialog[stage[stageId].dialogId];
            ChangeText();
        } 
        
        if (stage[stageId].dialogId == stage[stageId].dialog.Count - 1) {
            stage[stageId].hasBeenShown = true;
            if (stage[stageId].dialogId < 2)
                StartCoroutine(Skip());
            if (!stage[stageId].isToRepeat) NextStage();
        }
    }

    private void SkipToEnd() {
        director.time = 10f;
    }

    public void Interact() {
        if(stage[stageId] != null) {

            // Add condition where the player has all the scrolls

            if(!stage[stageId].hasBeenShown) {
                director.Play();
            }
            if(stage[stageId].isToRepeat) {
                stage[stageId].dialogId = -1;
                director.Play();
            }
        }
    }

    private void PlaySounds() {
        aSource.clip = voiceLines[Random.Range(0, voiceLines.Count - 1)];
        aSource.Play();
    }

    private IEnumerator Skip() {
        yield return new WaitForSeconds(3f);
        SkipToEnd();
    }
} 

[System.Serializable]
public class CutScenePhase {
    [TextArea(5, 5)]
    public List<string> dialog;
    public int dialogId = -1;
    public bool hasBeenShown;
    public bool isToRepeat;
}
