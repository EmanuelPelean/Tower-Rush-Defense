﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField] Color exploredColor;
    public bool isExplored = false; // ok as is a data class
    public Waypoint exploredFrom;

    Vector2Int gridPos;

    const int gridSize = 10;
    
    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int getGridPos()
    {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize)
        );

    }

    public void setTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
      
    }

    public void setExploredColor()
    {
        if (isExplored)
        {
            print(exploredColor);
            setTopColor(exploredColor);
        }
        else
        {
            setTopColor(Color.cyan);
        }
    }

    void Update () {
        //setExploredColor(); 
	}
}
