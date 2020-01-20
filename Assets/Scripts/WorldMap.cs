using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    public int width, height;
    public GameObject TilePrefab;
    WorldTile[,] mapData;
    GameObject errorTile;

    private void Awake()
    {
        mapData = new WorldTile[,] { };
    }

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        // Random.InitState(37);
        ClearMap();
        mapData = new WorldTile[width, height];


        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                GameObject go = Instantiate(TilePrefab, this.transform);
                go.transform.position = new Vector3(x, y, 0);

                WorldTile wt = go.GetComponent<WorldTile>();
                wt.SetTileType((TileType)Random.Range(0,6));

                mapData[x, y] = wt;
            }
        }
    }

    void ClearMap()
    {
        foreach(WorldTile t in mapData)
        {
            Destroy(t.gameObject);
        }

        mapData = new WorldTile[width, height];
    }

    public WorldTile GetTile(Vector3Int tilePos)
    {
        WorldTile tile;

        try
        { 
            tile = mapData[tilePos.x, tilePos.y];
        } catch(System.IndexOutOfRangeException)
        {
            if (!errorTile)
            {
                errorTile = Instantiate(TilePrefab, this.transform);
            }

            errorTile.transform.position = new Vector3(tilePos.x, tilePos.y, 0);
            tile = errorTile.GetComponent<WorldTile>();
            tile.SetTileType(TileType.ERROR);
        }

        if (tile.type != TileType.ERROR) Destroy(errorTile);
        return tile;
    }
}
