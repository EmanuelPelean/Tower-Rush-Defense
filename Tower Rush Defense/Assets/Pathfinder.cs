using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    void Start () {
        loadBlocks();
        colorStartAndEnd();
        exploreNeighbors();
	}

    private void exploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.getGridPos() + direction;
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].setTopColor(Color.blue);

            } 
            catch
            {
                // do nothing
            }
        }
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
