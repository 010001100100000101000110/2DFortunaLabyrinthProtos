using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Helper
{
    UIHandler_G ballUI;
 
    GameObject selected;
    bool canLaunch;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;

    void Start()
    {
        ballUI = FindObjectOfType<UIHandler_G>();
        canLaunch = true;
    }


    void Update()
    {
        base.Update();
        if (canLaunch) LaunchBallMode();
    } 

    void LaunchBallMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("NAPSISTA SAATANA");
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
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

        Vector2 trajectoryDir = (playerPos - mousePosition).normalized;

        float distance = (Vector2.Distance(playerPos, mousePosition));
        float clampDistance = Mathf.Clamp(distance, 0, maxPullDistance);

        float force = clampDistance * launchForce;

        Debug.Log("distance on " + distance);
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
}
