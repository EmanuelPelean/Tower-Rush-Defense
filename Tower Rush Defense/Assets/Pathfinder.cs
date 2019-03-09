using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	void Start () {
        loadBlocks();
        colorStartAndEnd();
	}

    private void colorStartAndEnd()
    {
        startWaypoint.setTopColor(Color.green);
        endWaypoint.setTopColor(Color.red);
    }

    private void loadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.getGridPos());
            if(isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            } else
            {
                grid.Add(waypoint.getGridPos(), waypoint);
            }
        }
    }
}
