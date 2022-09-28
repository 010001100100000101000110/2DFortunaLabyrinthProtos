using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartingPointMover : Helper
{
    [SerializeField] GameObject selected;
    
    [SerializeField] Transform areaPoint1;
    [SerializeField] Transform areaPoint2;
        
    bool choosingStartPointMode;
    void Start()
    {
        choosingStartPointMode = true;
        ResetBallProperties();
    }

    void Update()
    {
        base.Update();
        if (choosingStartPointMode) MoveBallWithMouse();       
    }    

    void MoveBallWithMouse()
    {
        Debug.Log(mousePosition);
        this.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;     
        float xPos = Mathf.Clamp(mousePosition.x, areaPoint1.position.x, areaPoint2.position.x);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selected = targetObject.transform.gameObject;
            }            
        }
        if (selected && selected.tag == "Player")
        {
            selected.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0) && selected && selected.tag == "Player")
        {
            selected = null;
        }
    }
   
    public void ResetBallProperties()
    {
        this.transform.position = (areaPoint1.transform.position + areaPoint2.transform.position) / 2;
        rigidbody.velocity = Vector2.zero;
        rigidbody.isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        rigidbody.freezeRotation = true;   
        
    }
    public void SetStartingPoint()
    {
        choosingStartPointMode = false;
    }
    public void ResetStartingPoint()
    {
        choosingStartPointMode = true;        
    }
}
