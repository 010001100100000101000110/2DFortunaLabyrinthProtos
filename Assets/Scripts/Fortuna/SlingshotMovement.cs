using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlingshotMovement : Helper
{
    UIHandler ballUI;

    GameObject selected;
    bool canLaunch;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;
    Vector2 playerStartingPoint;
    
    void Start()
    {
        ballUI = FindObjectOfType<UIHandler>();
        //canLaunch = true;
        playerStartingPoint = this.transform.position;
        rigidbody.isKinematic = true;
    }


    void Update()
    {
        if (canLaunch) LaunchBallMode();
    } 

    void LaunchBallMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(GetMousePosition());
            if (targetObject)
            {
                selected = targetObject.transform.gameObject;
            }            
        }
        if (selected && selected.tag == "Player") ballUI.CanLineRender();
        if (Input.GetMouseButtonUp(0) && selected && selected.tag == "Player")
        {
            selected = null;
            ballUI.CantLineRender();
            LaunchBall();
            eventMethods.BallLaunched();
        }
    }

    void LaunchBall()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.constraints = RigidbodyConstraints2D.None;
        

        Vector2 playerPos = transform.position;
        rigidbody.freezeRotation = false;
        eventMethods.BallLaunched();

        Vector2 trajectoryDir = (playerPos - GetMousePosition()).normalized;

        float clampDistance = Mathf.Clamp(GetDistance(), 0, maxPullDistance);

        float force = clampDistance * launchForce;

        Debug.Log("distance on " + GetDistance());
        Debug.Log("clampDistance on " + clampDistance);
        Debug.Log("force on " + force);

        rigidbody.AddForce(trajectoryDir * force, ForceMode2D.Impulse);
        canLaunch = false;
    }
    public void ActivateLaunching()
    {
        canLaunch = true;
    }
    public void DeActivateLaunching()
    {
        canLaunch = false;
    }
    public float GetMaxDistance()
    {
        return maxPullDistance;
    }

    public void ResetBallProperties()
    {
        this.transform.position = playerStartingPoint;
        rigidbody.velocity = Vector2.zero;
        rigidbody.isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        rigidbody.freezeRotation = true;
    }
}
