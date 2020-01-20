using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3Int worldPosition;
    public float moveTime = 0.25f;

    WorldMap map;

    float t = 0.0f;
    Vector3 startPos;

    private void Start()
    {
        map = GameObject.Find("World Map").GetComponent<WorldMap>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveActor(Vector3Int.up);
        } else if(Input.GetKeyDown(KeyCode.S))
        {
            MoveActor(Vector3Int.down);
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveActor(Vector3Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveActor(Vector3Int.left);
        }

        if (t < 1)
        {
            t += Time.deltaTime / moveTime;
        } else if( t >= 1)
        {
            t = 1;
        }

        transform.position = Vector3.Lerp(startPos, worldPosition, t);
    }

    public void MoveActor(Vector3Int direction)
    {
        Vector3Int newPos = worldPosition + direction;
        WorldTile targetTile = map.GetTile(newPos);

        if(targetTile.type == TileType.ERROR || targetTile.type == TileType.VOID)
        {
            return;
        } else
        {
            worldPosition = newPos;

            t = 0;
            startPos = transform.position;
        }
    }
}
