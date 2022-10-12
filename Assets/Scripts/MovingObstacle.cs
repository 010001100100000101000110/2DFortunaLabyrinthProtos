using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] GameObject obstacle;
    public int currentWaypointIndex;
    bool ascending;

    // Start is called before the first frame update
    void Start()
    {
        ascending = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = currentWaypoint() - obstacle.transform.position;
        obstacle.transform.position += direction.normalized * speed * Time.deltaTime;
        if (Vector3.Distance(obstacle.transform.position, currentWaypoint()) < 0.1f)
        {
            nextWaypoint();
        }
    }

    void nextWaypoint()
    {
        if (currentWaypointIndex == waypoints.Count - 1) 
        {
            ascending = false;
        } 

        else if (currentWaypointIndex == 0)
        {
            ascending = true;
        }
        
        switch (ascending)
        {
            case true:
                {
                    currentWaypointIndex++;
                    break;
                }

            case false:
                {
                    currentWaypointIndex--;
                    break;
                }
        }
    }

    Vector3 currentWaypoint()
    {
        return waypoints[currentWaypointIndex].position;
    }
}
