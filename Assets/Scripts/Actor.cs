﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public Vector3Int worldPosition;
    public float moveTime = 0.25f;
    public bool playerControlled;

    WorldMap map;

    // Animation Vars
    float t = 0.0f;
    Vector3 startPos;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        map = GameObject.Find("World Map").GetComponent<WorldMap>();
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
}