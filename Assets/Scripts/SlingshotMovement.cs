using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlingshotMovement : MonoBehaviour
{
    EventListenerMethods eventMethods;
    UIBallLaunchForce ballUI;
    Rigidbody2D rigidbody;

    [SerializeField] GameObject selectedPlayer;
    //Vector3 offset;
    [SerializeField] float launchForce;
    [SerializeField] float maxForce;

    [SerializeField] bool canLaunch;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        eventMethods = FindObjectOfType<EventListenerMethods>();
        ballUI = GetComponent<UIBallLaunchForce>();
    }


    void Update()
    {
        if (canLaunch) LaunchBallMode();

    }

    public void ActivateLaunching()
    {
        canLaunch = true;
    }
    public void DeActivateLaunching()
    {
        canLaunch = false;
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
                //offset = selectedPlayer.transform.position - mousePosition;
            }
            
        }
        if (selectedPlayer && selectedPlayer.tag == "Player")
        {
            //Debug.Log(Vector3.Distance(this.transform.position, mousePosition));
            ballUI.CanLineRender();
        }
        if (Input.GetMouseButtonUp(0) && selectedPlayer && selectedPlayer.tag == "Player")
        {
            selectedPlayer = null;
            Debug.Log("LAUNCHED BALL");
            ballUI.CantLineRender();
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.constraints = RigidbodyConstraints2D.None;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = this.transform.position;
        this.rigidbody.freezeRotation = false;
        eventMethods.BallLaunched();

        Vector2 trajectoryDir = playerPos - mousePosition;
        
        float force = (Vector2.Distance(playerPos, mousePosition)) * launchForce;
        float clampForce = Mathf.Clamp(force, 0, maxForce);

        Debug.Log("distance on " + Vector2.Distance(playerPos, mousePosition));
        Debug.Log("force on " + force);
        Debug.Log("clampattu force " + clampForce);

        rigidbody.AddForce(trajectoryDir.normalized * clampForce, ForceMode2D.Force);
        canLaunch = false;
    }
}
