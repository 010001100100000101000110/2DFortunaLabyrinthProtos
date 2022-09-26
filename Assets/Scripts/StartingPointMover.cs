using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointMover : MonoBehaviour
{
    [SerializeField] GameObject player;
    Rigidbody2D rigidbody;

    [SerializeField] GameObject selectedPlayer;
    Vector3 offset;

    [SerializeField] Transform areaPoint1;
    [SerializeField] Transform areaPoint2;

    [SerializeField] float lerpSpeed;

    bool startModeActive;

    void Start()
    {
        startModeActive = true;
        rigidbody = GetComponent<Rigidbody2D>();
        ResetBallProperties();
    }

    void Update()
    {     
        if (startModeActive) MoveBallWithMouse();       
    }
    

    void MoveBallWithMouse()
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
            //selectedPlayer.transform.position = mousePosition + offset;
            this.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, mousePosition.x);
        }
        if (Input.GetMouseButtonUp(0) && selectedPlayer)
        {
            selectedPlayer = null;
        }
    }

    //void MoveBallAtStart()
    //{
    //    this.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, Mathf.PingPong(Time.time * lerpSpeed, 1));
    //}

    public void ResetBallProperties()
    {
        this.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, 0.5f);
        rigidbody.velocity = Vector2.zero;
        this.transform.rotation = Quaternion.identity;
    }
    public void SetStartingPoint()
    {
        startModeActive = false;
    }
    public void ResetStartingPoint()
    {
        startModeActive = true;        
    }
}
