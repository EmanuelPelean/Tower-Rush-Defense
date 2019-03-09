using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        snapToGrid();
        updateLabel();
    }

    private void snapToGrid()
    {
        int gridSize = waypoint.getGridSize();
        transform.position = new Vector3(
            waypoint.getGridPos().x, 
            0f, 
            waypoint.getGridPos().y);
    }

    private void updateLabel()
    {
        int gridSize = waypoint.getGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.getGridPos().x / gridSize + "," + waypoint.getGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
