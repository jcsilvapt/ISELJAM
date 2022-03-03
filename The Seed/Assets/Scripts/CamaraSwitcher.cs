using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamaraSwitcher : MonoBehaviour {

    public enum TypeSwitcher {
        Entrance,
        Exit
    }

    [Header("References")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineVirtualCamera desireCamera;

    [Header("Settings")]
    [SerializeField] TypeSwitcher type;
    [SerializeField] float timeToSwapCamera = 2.0f;

    private c_PlayerController player;


    private void RotatePlayer() {
        switch(type) {
            case TypeSwitcher.Entrance:
                desireCamera.gameObject.SetActive(true);
                mainCamera.gameObject.SetActive(false);
                StartCoroutine(SwapCamera(desireCamera));
                break;
            case TypeSwitcher.Exit:
                if (!player.IsActiveCameraMain()) {
                    desireCamera.gameObject.SetActive(false);
                    mainCamera.gameObject.SetActive(true);
                    StartCoroutine(SwapCamera(mainCamera));
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            player = other.GetComponent<c_PlayerController>();
            RotatePlayer();
        }
    }

    private IEnumerator SwapCamera(CinemachineVirtualCamera camera) {
        yield return new WaitForSeconds(timeToSwapCamera);
        player.ChangeActiveCamera(camera);
    }
}
