using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlingshotMovement : MonoBehaviour
{
    EventListenerMethods eventMethods;
    Rigidbody2D rigidbody;

    [SerializeField] GameObject selectedPlayer;
    Vector3 offset;

    bool launchingActive;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        eventMethods = FindObjectOfType<EventListenerMethods>();
    }


    void Update()
    {
        if (launchingActive) LaunchBallMode();

    }

    public void ActivateLaunching()
    {
        launchingActive = true;
    }
    public void DeActivateLaunching()
    {
        launchingActive = false;
    }

    void LaunchBallMode()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedPlayer = targetObject.transform.gameObject;
                offset = selectedPlayer.transform.position - mousePosition;
            }
        }
        if (selectedPlayer)
        {
            //dragImage.SetActive(true);            
            //dragImage.transform.position = mousePosition + offset;
            Debug.Log(Vector3.Distance(this.transform.position, mousePosition));
        }
        if (Input.GetMouseButtonUp(0) && selectedPlayer)
        {
            selectedPlayer = null;
            Debug.Log("LAUNCHED BALL");
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = this.transform.position;
        eventMethods.BallLaunched();

        Vector2 trajectoryDir = playerPos - mousePosition;
        float launchForce = Vector2.Distance(playerPos, mousePosition) * 20;
        rigidbody.AddForce(trajectoryDir * launchForce);
    }
}
