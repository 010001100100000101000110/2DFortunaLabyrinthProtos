using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover_G : MonoBehaviour
{    
    GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") mainCamera.transform.position = collision.gameObject.transform.position;      
    }
}
