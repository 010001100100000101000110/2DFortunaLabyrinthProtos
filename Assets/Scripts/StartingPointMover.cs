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

    void Start()
    {
        StartCoroutine(LinearMovementBack());
    }

    void Update()
    {
        

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

    //IEnumerator LinearMovementTo()
    //{
    //    float ElapsedTime = 0;
    //    float TotalTime = 3;

    //    while (ElapsedTime < TotalTime)
    //    {
    //        ElapsedTime += Time.deltaTime;
    //        player.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, ElapsedTime/TotalTime );

    //    }
    //   //StartCoroutine(LinearMovementBack());
    //    yield return null;
    //}

    IEnumerator LinearMovementBack()
    {
        float ElapsedTime = 3;
        float TotalTime = 0;

        while (ElapsedTime > TotalTime)
        {
            ElapsedTime -= Time.deltaTime;
            player.transform.position = Vector3.Lerp(areaPoint1.position, areaPoint2.position, TotalTime / ElapsedTime);
        }
        //StartCoroutine(LinearMovementTo());
        yield return null;
    }
}
