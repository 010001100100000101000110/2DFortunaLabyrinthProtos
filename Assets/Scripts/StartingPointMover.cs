using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartingPointMover : MonoBehaviour
{
    [SerializeField] GameObject player;
    Rigidbody2D rigidbody;

    [SerializeField] GameObject selectedPlayer;
    //Vector3 offset;

    [SerializeField] Transform areaPoint1;
    [SerializeField] Transform areaPoint2;

    //[SerializeField] float lerpSpeed;

    [SerializeField] bool choosingStartPointMode;


    void Start()
    {
        choosingStartPointMode = true;
        rigidbody = GetComponent<Rigidbody2D>();
        ResetBallProperties();
    }

    void Update()
    {     
        if (choosingStartPointMode) MoveBallWithMouse();       
    }
    

    void MoveBallWithMouse()
    {
        this.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;     
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xPos = Mathf.Clamp(mousePosition.x, areaPoint1.position.x, areaPoint2.position.x);
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
            selectedPlayer.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0) && selectedPlayer && selectedPlayer.tag == "Player")
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
        this.transform.position = (areaPoint1.transform.position + areaPoint2.transform.position) / 2;
        rigidbody.velocity = Vector2.zero;
        this.transform.rotation = Quaternion.identity;
        this.rigidbody.freezeRotation = true;        
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
