using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerToStart : Helper_G
{
    Vector2 startPos;
    void Start()
    {
        startPos = GameObject.FindGameObjectWithTag("Start").transform.position;
        player.transform.position = startPos;
    }
    public void ResetPositionToStart()
    {
        player.transform.position = startPos;
        movement.ResetMovement();
    }
}
