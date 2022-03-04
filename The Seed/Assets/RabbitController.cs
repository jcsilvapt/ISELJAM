using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    private void Start() {
        StartCoroutine(Disable());
    }

    private void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player")) {
            gameObject.SetActive(false);
            StopCoroutine(Disable());
        }
    }

    private IEnumerator Disable() {
        yield return new WaitForSeconds(15f);
    }

}
