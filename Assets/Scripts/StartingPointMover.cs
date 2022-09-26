using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointMover : MonoBehaviour
{
    GameObject selectedPlayer;
    Vector3 offset;

    [SerializeField] GameObject player;

    [SerializeField] Transform areaPoint1;
    [SerializeField] Transform areaPoint2;

    [SerializeField] float lerpSpeed;

    void Start()
    {
        //StartCoroutine(LinearMovementBack());
    }

    void Update()
    {
        SetLerpSpeed();


        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        //    if (targetObject)
        //    {
        //        selectedPlayer = targetObject.transform.gameObject;
        //        offset = selectedPlayer.transform.position - mousePosition;
        //    }
        //}
        //if (selectedPlayer)
        //{
        //    //selectedPlayer.transform.position = mousePosition + offset;
        //    player.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, limitMouse());
        //}
        //if (Input.GetMouseButtonUp(0) && selectedPlayer)
        //{
        //    selectedPlayer = null;
        //}
    }


    void SetLerpSpeed()
    {
        float length = 0;
        float totalLength = 7;
        bool addTime = false;

        if (length < 0) addTime = true;
        if (length > totalLength) addTime = false;

        while (addTime) length += Time.deltaTime;
        while (!addTime) length -= Time.deltaTime;

        lerpSpeed = length / totalLength;
    }

    IEnumerator LinearMovementTo()
    {
        float ElapsedTime = 0;
        float TotalTime = 3;

        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            player.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, ElapsedTime / TotalTime);
            
        }
        yield return null;
        //StartCoroutine(LinearMovementBack());

    }

    IEnumerator LinearMovementBack()
    {
        float ElapsedTime = 0;
        float TotalTime = 3;

        while (ElapsedTime < TotalTime)
        {
            TotalTime -= Time.deltaTime;
            player.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, TotalTime / ElapsedTime);
            yield return null;
        }
        //StartCoroutine(LinearMovementTo());
        
    }
}
