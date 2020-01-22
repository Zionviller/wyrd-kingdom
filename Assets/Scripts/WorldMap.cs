using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    [SerializeField]
    Vector2Int worldSize;
    WorldTile[,] mapData;

    public GameObject itemPrefab;

    public GameObject TilePrefab;
    GameObject errorTile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateMap();
        }
    }

    public void GenerateMap()
    {
        // Random.InitState(37);
        // ClearMap(); // TODO: instead of clearing, reuse existing GOs

        if (mapData == null) mapData = new WorldTile[worldSize.x, worldSize.y];

        for (int y = 0; y < worldSize.y; y++)
        {
            for (int x = 0; x < worldSize.x; x++)
            {
                GameObject go;

                if (!mapData[x, y])
                {
                    go = Instantiate(TilePrefab, this.transform);
                    go.transform.position = new Vector3(x, y, 0);

                }
                else
                {
                    go = mapData[x, y].gameObject;

                }

                WorldTile wt = go.GetComponent<WorldTile>();
                wt.SetTileType((TileType)Random.Range(0, 6));
                wt.worldPos = new Vector2Int(x, y);

                mapData[x, y] = wt;
            }
        }

        AddItems(200);
    }

    public void AddItems(int num)
    {
        for(int i = 0; i < num; i++)
        {
            WorldTile tile = GetRandomTileOfType(TileType.GRASS);
            Item newItem = Instantiate(itemPrefab).GetComponent<Item>();
            tile.AddItem(newItem);                        
        }
    }

    void ClearMap()
    {
        foreach (WorldTile t in mapData)
        {
            Destroy(t.gameObject);
        }

        mapData = new WorldTile[worldSize.x, worldSize.y];
    }

    public WorldTile GetTile(Vector3Int tilePos)
    {
        WorldTile tile;

        try
        {
            tile = mapData[tilePos.x, tilePos.y];
        }
        catch (System.IndexOutOfRangeException)
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

    public List<WorldTile> getTilesOfType(TileType type)
    {
        List<WorldTile> tiles = new List<WorldTile>();

        foreach (WorldTile t in mapData)
        {
            if (t.type == type)
            {
                tiles.Add(t);
            }
        }

        return tiles;
    }

    public WorldTile GetRandomTileOfType(TileType type)
    {
        List<WorldTile> tiles = getTilesOfType(type);

        return tiles[Random.Range(0, tiles.Count - 1)];
    }
}
