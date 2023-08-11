using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Dragging> draggingObjects;
    public float snapRange = 0.5f;
    private Dragging dragged;

    private void Start()
    {
        dragged = FindObjectOfType<Dragging>();
        foreach (Dragging dragging in draggingObjects)
        {
            dragging.dragEndedCallback = OnDragEnded;
            CheckCollisions(dragging); // Initial check
        }
    }

    private void Update()
    {
        // Loop through all the dragging objects and check for collisions
            foreach (Dragging dragging in draggingObjects)
            {
                CheckCollisions(dragging);
            }
    }

    private void OnDragEnded(Dragging dragging)
    {
        if (!dragging.IsDragged) // Check if the piece is not being dragged
        {
            // Check for collisions for the specific dragging object
            CheckCollisions(dragging);
        }
    }

    private void CheckCollisions(Dragging dragging)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(dragging.transform.position, snapPoint.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            dragging.transform.position = closestSnapPoint.position;
        }
    }
}