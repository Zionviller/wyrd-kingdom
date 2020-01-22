using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Actor : MonoBehaviour
{
    public Vector3Int worldPosition;
    public float moveTime = 0.25f;
    public bool playerControlled;

    public WorldMap map;

    // Animation Vars
    float t = 1.0f;
    Vector3 startPos;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (t < 1)
        {
            t += Time.deltaTime / moveTime;
        }
        else if (t >= 1)
        {
            t = 1;
        }

        transform.position = Vector3.Lerp(startPos, worldPosition, t);
    }

    public void SetPosition(Vector3Int newPos)
    {
        worldPosition = newPos;
        transform.position = newPos;
        
    }

    public void MoveActor(Vector3Int direction)
    {
        Vector3Int newPos = worldPosition + direction;
        WorldTile targetTile = map.GetTile(newPos);

        if (direction == Vector3Int.left)
            spriteRenderer.flipX = true;
        else if (direction == Vector3Int.right)
            spriteRenderer.flipX = false;

        if (targetTile.type == TileType.ERROR || targetTile.type == TileType.VOID)
        {
            return;
        }
        else
        {
            worldPosition = newPos;

            t = 0;
            startPos = transform.position;
        }
    }

    public void PickUpItem()
    {
        // TODO: currently destroys all items in position, later move to inventory
        WorldTile currentTile = map.GetTile(worldPosition);

        if (currentTile.items.Count == 0)
        {
            Debug.Log("No items in this location.");
            return;
        }

        string ess = currentTile.items.Count > 1 ? "s" : "";
        Debug.Log($"Eating {currentTile.items.Count} apple{ess}.");
        for(int i = currentTile.items.Count - 1; i >= 0; i--)
        {
            Item itemToRemove = currentTile.items[i];
            currentTile.items.Remove(itemToRemove);
            Destroy(itemToRemove.gameObject);
        }
    }
}
