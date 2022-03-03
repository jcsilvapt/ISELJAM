using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_StoreWarning : MonoBehaviour {

    public CanvasGroup warningPanel;
    public Transform player;
    public float timePerWarning;
    public float timeDuringWarning;

    private float elapsedTime;

    private RectTransform rt;

    public bool isRunning;

    public bool hasPlayer;


    private void Awake() {
        rt = warningPanel.GetComponent<RectTransform>();
    }

    private void Update() {
        if (hasPlayer) {
            rt.LookAt(Camera.main.transform);
        }

        if(elapsedTime >= timePerWarning) {
            StartCoroutine(FadeIn());
            elapsedTime = 0f;
        } else {
            elapsedTime += Time.deltaTime;
        }

    }


    private IEnumerator FadeIn() {
        if (!isRunning) {
            isRunning = true;
            float alpha = 0f;
            while (isRunning) {

                if (alpha <= 1f) {
                    warningPanel.alpha = alpha;
                    alpha += Time.deltaTime;
                } else {
                    isRunning = false;
                }
                yield return null;
            }
            isRunning = false;

            yield return new WaitForSeconds(timeDuringWarning);
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut() {
        if (!isRunning) {
            isRunning = true;
            float alpha = 1f;
            while (isRunning) {

                if (alpha >= 0f) {
                    warningPanel.alpha = alpha;
                    alpha -= Time.deltaTime;
                } else {
                    isRunning = false;
                }
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")) {
            hasPlayer = true;
            elapsedTime = timePerWarning;
        }
    }

    private void OnTriggerExit(Collider other) {
        hasPlayer = false;
    }
}
