using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover_G : MonoBehaviour
{
    [SerializeField] Transform destinationCameraPoint;
    GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") mainCamera.transform.position = destinationCameraPoint.position;
    }
}
