﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.getPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            Vector3 waypointPosition = waypoint.transform.position;
            waypointPosition.y = 5;
            transform.position = waypointPosition;
            yield return new WaitForSeconds(.5f);
        }
        print("Ending patrol");
    }
}