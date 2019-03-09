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
        while(queue.Count > 0 && isRunning)
        {
           var searchCenter = queue.Dequeue();
           searchCenter.isExplored = true;
           print("Searching from " + searchCenter); // todo remove log
           stopIfEndFound(searchCenter);
           exploreNeighbors(searchCenter);
        }

        // todo finish path logic
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

    private void exploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.getGridPos() + direction;
            print("Exploring " + neighborCoordinates);
            try
            {
                queueNewNeighbors(neighborCoordinates);
            } 
            catch
            {
                // do nothing
            }
        }
    }

    private void queueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored)
        {
            // do nothing
        }
        else
        {
            neighbor.setTopColor(Color.blue); // todo move
            queue.Enqueue(neighbor);
            print("Queueing" + neighbor);
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
