using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class c_StoreWarning : MonoBehaviour {

    [Header("References")]
    [SerializeField] CanvasGroup warningPanel;
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator anim;

    [Header("Dialog")]
    [SerializeField] List<string> dialogs;

    [Header("Settings")]
    [SerializeField] float timePerWarning;
    [SerializeField] float warningDuration;
    [SerializeField] float lastTimePlayerHasEntered;

    [Header("Developer Settings")]
    [SerializeField] bool isShowingWarning;
    [SerializeField] bool hasPlayerEntered;

    [SerializeField] float elapsedTimePerWarning;
    [SerializeField] float elapsedLastTimePlayerHasEntered;
    [SerializeField] int dialogId;

    private RectTransform rt;

    private void Awake() {
        rt = warningPanel.GetComponent<RectTransform>();
        elapsedLastTimePlayerHasEntered = lastTimePlayerHasEntered;
        elapsedTimePerWarning = timePerWarning;
        text.SetText(dialogs[dialogId]);
    }

    private void Update() {

        rt.LookAt(Camera.main.transform);


        HandleTimePerWarning();

        if (hasPlayerEntered) {
            if (HandleLastTimePlayerEnter() && !isShowingWarning) {
                elapsedTimePerWarning = timePerWarning;
            }
        }

    }

    private void HandleTimePerWarning() {
        if (elapsedTimePerWarning >= timePerWarning) {
            elapsedTimePerWarning = 0f;
            StartCoroutine(FadeIn());
            isShowingWarning = true;
            anim.SetTrigger("isSayingHello");
        } else {
            elapsedTimePerWarning += Time.deltaTime;
        }
    }

    private bool HandleLastTimePlayerEnter() {

        if (elapsedLastTimePlayerHasEntered >= lastTimePlayerHasEntered) {
            elapsedLastTimePlayerHasEntered = 0f;
            hasPlayerEntered = false;
            return true;
        } else {
            elapsedLastTimePlayerHasEntered += Time.deltaTime;
            return false;
        }

    }


    private IEnumerator FadeIn() {

        bool controller = true;

        float alpha = 0f;
        while (controller) {

            if (alpha <= 1f) {
                warningPanel.alpha = alpha;
                alpha += Time.deltaTime;
            } else {
                controller = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(warningDuration);
        StartCoroutine(FadeOut());

    }

    private IEnumerator FadeOut() {

        bool controller = true;
        float alpha = 1f;
        while (controller) {

            if (alpha >= 0f) {
                warningPanel.alpha = alpha;
                alpha -= Time.deltaTime;
            } else {
                isShowingWarning = false;
            }
            yield return null;
        }

    }

    public void NextDialog() {
        dialogId++;
        text.SetText(dialogs[dialogId]);
        anim.SetTrigger("isTalking");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            hasPlayerEntered = true;
            anim.SetTrigger("isSayingHello");
        }
    }
}
