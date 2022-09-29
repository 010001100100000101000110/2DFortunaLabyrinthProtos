using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Helper_G
{
    UIHandler_G ballUI;
 
    GameObject selected;
    bool canLaunch;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;

    Vector3 lastPosition;

    void Start()
    {
        ballUI = FindObjectOfType<UIHandler_G>();
        canLaunch = true;
    }


    void Update()
    {
        base.Update();
        if (canLaunch) LaunchBallMode();
        if (rigidbody.velocity.magnitude < 0.5)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
            if (rigidbody.velocity.magnitude == 0) eventMethods.BallStopped();
        }
    }

    void LaunchBallMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject) selected = targetObject.transform.gameObject;
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
        rigidbody.freezeRotation = false;        

        Vector2 playerPos = transform.position;
        Vector2 trajectoryDir = (playerPos - mousePosition).normalized;
        float distance = (Vector2.Distance(playerPos, mousePosition));
        float clampDistance = Mathf.Clamp(distance, 0, maxPullDistance);
        float force = clampDistance * launchForce;

        lastPosition = this.transform.position;
        rigidbody.AddForce(trajectoryDir * force, ForceMode2D.Impulse);
        eventMethods.BallLaunched();
        canLaunch = false;
    }
    public void CanLaunch()
    {
        canLaunch = true;
    }
    public void CantLaunch()
    {
        canLaunch = false;
    }
    public float GetMaxDistance()
    {
        return maxPullDistance;
    }

    public void ResetMovement()
    {
        rigidbody.velocity = new Vector3(0, 0, 0);
        
    }
}
