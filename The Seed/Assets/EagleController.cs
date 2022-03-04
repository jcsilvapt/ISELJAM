using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour {

    public float speed = 1.0f;
    public Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Disable());
    }

    private void Update() {

        transform.position += transform.forward * Time.deltaTime * speed;

    }

    private IEnumerator Disable() {
        yield return new WaitForSeconds(20f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        StopCoroutine(Disable());
        gameObject.SetActive(false);
    }

}
