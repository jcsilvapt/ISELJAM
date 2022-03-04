using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * Time.deltaTime * movementSpeed;
    }
}
