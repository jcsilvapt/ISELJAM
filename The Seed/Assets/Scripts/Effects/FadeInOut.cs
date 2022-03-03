using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {

    [Header("References")]
    [SerializeField] CanvasGroup cg;

    [Header("Settings")]
    [SerializeField] float fadeInTime;
    [SerializeField] float middleTime;
    [SerializeField] float fadeOutTime;

    [Header("Developer Settings")]
    [SerializeField] FadeState currentState = FadeState.Initial;

    private float elapsedFadeInTime;
    private float elapsedMiddleTime;
    private float elapsedFadeOutTime;

    public bool isRunning;

    public void EnableEffect() {
        isRunning = true;
    }

    void Update() {
        if(isRunning) {
            switch(currentState) {
                case FadeState.Initial:
                    FadeInAnimation();
                    break;
                case FadeState.Middle:
                    MiddleAnimation();
                    break;
                case FadeState.Out:
                    FadeOutAnimation();
                    break;
                case FadeState.End:
                    isRunning = false;
                    currentState = FadeState.Initial;
                    break;
            }
        }
    }

    private void FadeInAnimation() {
        if(elapsedFadeInTime >= fadeInTime) {
            currentState = FadeState.Middle;
            elapsedFadeInTime = 0f;
        } else {
            cg.alpha = (Mathf.Clamp(elapsedFadeInTime, 0, 1));
            elapsedFadeInTime += Time.deltaTime;
        }
    }

    private void MiddleAnimation() {
        if (elapsedMiddleTime >= middleTime) {
            currentState = FadeState.Out;
            elapsedMiddleTime = 0f;
        } else {
            elapsedMiddleTime += Time.deltaTime;
        }
    }

    private void FadeOutAnimation() {
        if (elapsedFadeOutTime >= fadeOutTime) {
            currentState = FadeState.End;
            elapsedFadeOutTime = 0f;
        } else {
            cg.alpha = (Mathf.Clamp(elapsedFadeOutTime, 1, 0));
            elapsedFadeOutTime += Time.deltaTime;
        }
    }
}

public enum FadeState {
    Initial,
    Middle,
    Out,
    End
}
