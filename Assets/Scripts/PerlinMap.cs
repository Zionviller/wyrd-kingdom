using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMap : MonoBehaviour
{
    public Vector2Int mapSize;
    public Vector2 sampleOrigin;
    public float scale = 1.0f;
    public GameObject TilePrefab;
    
    WorldTile[,] tileData;
    float[,] mapData;

    private void Awake()
    {
        tileData = new WorldTile[mapSize.x,mapSize.y];
        mapData = new float[mapSize.x,mapSize.y];
    }

    private void Start()
    {
        for(float y = 0; y < mapSize.y; y++)
        {
            for(float x = 0; x < mapSize.x; x++)
            {
                float xCoord = sampleOrigin.x + x / mapSize.x * scale;
                float yCoord = sampleOrigin.y + y / mapSize.y * scale;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                mapData[(int)x, (int)y] = sample;
            }
        }

        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                GameObject go = Instantiate(TilePrefab, this.transform);
                go.transform.position = new Vector3(x, y, 0);

                WorldTile wt = go.GetComponent<WorldTile>();
                Debug.Log($"{x},{y}: {mapData[x, y]}");
                wt.SetTileType((TileType) Mathf.Floor(mapData[x,y] * 5));

                tileData[x, y] = wt;
            }
        }

    }

    void CalcNoise()
    {
        float y = 0.0f;
        while(y < mapSize.y)
        {
            float x = 0.0f;
            while(x < mapSize.x)
            {

            }
        }
    }
}
