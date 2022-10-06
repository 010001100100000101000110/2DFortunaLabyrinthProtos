using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    Vector2 mousePosition;
    float distance;
    public GameObject player { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public EventListenerMethods eventMethods { get; private set; }
    public Collecting collecting { get; private set; }
    public AudioManager audioManager { get; private set; }
    
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
        eventMethods = FindObjectOfType<EventListenerMethods>();
        collecting = FindObjectOfType<Collecting>();
        audioManager = FindObjectOfType<AudioManager>();
    }    
    public Vector2 GetMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
    public float GetDistance()
    {
        distance = Vector3.Distance(player.transform.position, GetMousePosition());
        return distance;
    }
}
