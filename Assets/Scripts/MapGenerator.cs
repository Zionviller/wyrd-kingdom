using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerator
{
    public static TileType[,] RandomMap(Vector2Int mapSize)
    {
        // Random.InitState(seed); // Maybe roll my own PRNG?
        TileType[,] newMapData = new TileType[mapSize.x, mapSize.y];

        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                newMapData[x, y] = (TileType)Random.Range(1, 7);
            }
        }

        return newMapData;
    }

    public static TileType[,] SolidMap(TileType type, Vector2Int mapSize)
    {
        TileType[,] newMapData = new TileType[mapSize.x, mapSize.y];

        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                newMapData[x, y] = type;
            }
        }

        return newMapData;
    }

}
