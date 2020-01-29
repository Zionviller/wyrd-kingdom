using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerator
{
    public static TileType[,] RandomMap(Vector2Int mapSize, int seed = 37)
    {
        Random.InitState(seed);
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
}
