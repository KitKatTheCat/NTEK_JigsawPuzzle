using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<GameObject> occupyingObjects = new List<GameObject>();

    public Color occupiedColor;
    public Color vacantColor;

    private void Update()
    {
        if (occupyingObjects.Count > 0)
        {
            GetComponent<SpriteRenderer>().color = occupiedColor;
        }
        else 
        {
            GetComponent<SpriteRenderer>().color = vacantColor;
        }
    }

    public bool IsOccupied()
    {
        return occupyingObjects.Count > 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Selectable"))
        {
            occupyingObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.CompareTag("Selectable"))
        {
            occupyingObjects.Remove(exit.gameObject);
        }
    }
}
