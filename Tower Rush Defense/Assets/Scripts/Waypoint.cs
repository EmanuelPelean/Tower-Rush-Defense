﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField] Color exploredColor;
    public bool isExplored = false; // ok as is a data class
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    
    Vector2Int gridPos;

    const int gridSize = 10;
    
    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize)
        );

    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
      
    }

    public void SetExploredColor()
    {
        if (isExplored)
        {
            print(exploredColor);
            SetTopColor(exploredColor);
        }
        else
        {
            SetTopColor(Color.cyan);
        }
    }

    void Update () {
        //setExploredColor(); 
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can't place tower here.");
            }
        }
    }
}
