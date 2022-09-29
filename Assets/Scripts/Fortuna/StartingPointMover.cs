using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartingPointMover : Helper
{
    GameObject selectedObject;    
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
        this.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;     
        float xPos = Mathf.Clamp(mousePosition.x, areaPoint1.position.x, areaPoint2.position.x);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D target = Physics2D.OverlapPoint(mousePosition);
            if (target) selectedObject = target.transform.gameObject;         
        }
        if (selectedObject && selectedObject.tag == "Player") selectedObject.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonUp(0) && selectedObject && selectedObject.tag == "Player") selectedObject = null;
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
