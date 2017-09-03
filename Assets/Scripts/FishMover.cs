using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour {

    public GameObject fish;

    public GameObject[] myWaypoints; // array of all the waypoints

    [Range(0.0f, 10.0f)] // create a slider in the editor and set limits on moveSpeed
    public float moveSpeed = 5f; // enemy move speed
    public float waitAtWaypointTime = 1f; // how long to wait at a waypoint before _moving to next waypoint

    public bool loop = true; // should it loop through the waypoints

    // private variables

    Transform _transform;
    int _myWaypointIndex = 0;       // used as index for My_Waypoints
    float _moveTime;
    float _vx = 0f;

    bool _moving = true;

    // Use this for initialization
    void Start()
    {
        _transform = fish.transform;
        _moveTime = 0f;
        _moving = true;
    }

    // game loop
    void Update()
    {
        // if beyond _moveTime, then start moving
        if (Time.time >= _moveTime)
        {
            Movement();
        }
    }

    void Movement()
    {
        // if there isn't anything in My_Waypoints
        if ((myWaypoints.Length != 0) && (_moving))
        {
            // make sure the enemy is facing the waypoint (based on previous movement)
			Flip(-_vx);

            // determine distance between waypoint and enemy
            _vx = myWaypoints[_myWaypointIndex].transform.position.x - _transform.position.x;

            // move towards waypoint
            _transform.position = Vector3.MoveTowards(_transform.position, myWaypoints[_myWaypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // if the enemy is close enough to waypoint, make it's new target the next waypoint
            if (Vector3.Distance(myWaypoints[_myWaypointIndex].transform.position, _transform.position) <= 0)
            {
                _myWaypointIndex++;
                _moveTime = Time.time + waitAtWaypointTime;
            }

            // reset waypoint back to 0 for looping, otherwise flag not moving for not looping
            if (_myWaypointIndex >= myWaypoints.Length)
            {
                if (loop)
                    _myWaypointIndex = 0;
                else
                    _moving = false;
            }
        }
    }

    // flip the enemy to face torward the direction he is moving in
    void Flip(float _vx)
    {

        // get the current scale
        Vector3 localScale = _transform.localScale;

        if ((_vx > 0f) && (localScale.x < 0f))
            localScale.x *= -1;
        else if ((_vx < 0f) && (localScale.x > 0f))
            localScale.x *= -1;

        // update the scale
        _transform.localScale = localScale;
    }
}
