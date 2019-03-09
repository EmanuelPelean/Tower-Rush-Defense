using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo make private
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
        //exploreNeighbors();
        Pathfind();
	}

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0)
        {
           var searchCenter = queue.Dequeue();
           print("Searching from " + searchCenter); // todo remove log
           stopIfEndFound(searchCenter);
        }

        print("Finished pathfinding");
    }

    private void stopIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping"); // todo remove log
            isRunning = false;
        }
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
