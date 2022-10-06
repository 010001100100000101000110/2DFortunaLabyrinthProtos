using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_G : MonoBehaviour
{
    public Vector2 mousePosition { get; private set; }
    public GameObject player { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public EventListenerMethods_G eventMethods { get; private set; }
    public Movement movement { get; private set; }
    public AudioHandler_G audioHandler { get; private set; }
    
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
        eventMethods = FindObjectOfType<EventListenerMethods_G>();
        movement = player.GetComponent<Movement>();
        audioHandler = FindObjectOfType<AudioHandler_G>();
    }

    public void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
