using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public List<Tile> cells; // Reference to your Tile objects
    private Tile tile;

    private void Start()
    {
        tile = FindObjectOfType<Tile>();
    }

    private void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        bool allTilesOccupied = true; // Assume all tiles are occupied initially

        foreach (Tile cell in cells)
        {
            if (!cell.IsOccupied()) // If any tile is not occupied
            {
                allTilesOccupied = false; // Set to false and exit loop
                break;
            }
        }

        if (allTilesOccupied)
        {
            Debug.Log("You win!"); // You can replace this with your win condition logic
        }
    }
}