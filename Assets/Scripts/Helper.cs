using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public Vector2 mousePosition { get; private set; }
    public GameObject player { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
    }
    
    public void Update()
    {        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
    }
}
