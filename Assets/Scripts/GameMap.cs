using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    Vector2Int mapSize;
    List<MapTile> tilePool;
    MapTile[,] tileMap;
    TileType[,] mapData;

    public GameObject applePrefab;

    public GameObject tilePrefab;
    GameObject errorTile;

    private void Awake()
    {
        tilePool = new List<MapTile>();
    }

    private void Update()
    {

    }

    public void UpdateMapView()
    {
        if (mapData == null)
        {
            Debug.LogError("Cannot update map. There is no map data.");
            return;
        }

        tileMap = new MapTile[mapSize.x, mapSize.y];

        if (tilePool.Count != mapSize.x * mapSize.y)
        {
            int delta = (mapSize.x * mapSize.y) - tilePool.Count;

            if (delta > 0)
            {
                for (int i = 0; i < delta; i++)
                {
                    MapTile newTile = Instantiate(tilePrefab, this.transform).GetComponent<MapTile>();
                    tilePool.Add(newTile);
                }
            }
            else
            {
                for (int i = 0; i > delta; i--)
                {
                    tilePool[tilePool.Count + i - 1].gameObject.SetActive(false);
                }
            }
        }

        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                tileMap[x, y] = tilePool[x + (y * mapSize.x)];
                tileMap[x, y].SetTileType(mapData[x, y]);
                tileMap[x, y].worldPos = new Vector2Int(x, y);

                GameObject tileGO = tileMap[x, y].gameObject;
                tileGO.transform.position = new Vector3(x, y, 0);
                tileGO.SetActive(true);
            }
        }
    }

    // TODO: Fix Adding Items
    //public void AddItems(int num)
    //{
    //    for (int i = 0; i < num; i++)
    //    {
    //        MapTile tile = GetRandomTileOfType(TileType.GRASS);
    //        Item newItem = Instantiate(itemPrefab).GetComponent<Item>();
    //        tile.AddItem(newItem);
    //    }
    //}

    public void SetTileData(TileType[,] data)
    {
        mapData = data;
        mapSize = new Vector2Int(data.GetLength(0), data.GetLength(1));
        UpdateMapView();
    }

    //void ClearMap()
    //{
    //    foreach (MapTile t in tileMap)
    //    {
    //        Destroy(t.gameObject);
    //    }

    //    tileMap = new MapTile[mapSize.x, mapSize.y];
    //}

    public MapTile GetTile(Vector3Int tilePos)
    {
        MapTile tile;

        try
        {
            tile = tileMap[tilePos.x, tilePos.y];
        }
        catch (System.IndexOutOfRangeException)
        {
            if (!errorTile)
            {
                errorTile = Instantiate(tilePrefab, this.transform);
            }

            errorTile.transform.position = new Vector3(tilePos.x, tilePos.y, 0);
            tile = errorTile.GetComponent<MapTile>();
            tile.SetTileType(TileType.ERROR);
        }

        if (tile.type != TileType.ERROR) Destroy(errorTile);
        return tile;
    }

    public List<MapTile> getTilesOfType(TileType type)
    {
        List<MapTile> tiles = new List<MapTile>();

        foreach (MapTile t in this.tileMap)
        {
            if (t.type == type)
            {
                tiles.Add(t);
            }
        }

        return tiles;
    }

    public MapTile GetRandomTile()
    {
        // TODO: There will be wierdness if all tiles are inactive.
        MapTile tile;
        do
        {
            tile = tilePool[Random.Range(0, tilePool.Count - 1)];
        } while (!tile.gameObject.activeSelf);
        return tile;
    }

    public MapTile GetRandomTileOfType(TileType type)
    {
        List<MapTile> tiles = getTilesOfType(type);

        return tiles[Random.Range(0, tiles.Count - 1)];
    }

    public void GrowApples(int count = 20)
    {
        for (int i = 0; i < count; i++)
        {
            MapTile tile = GetRandomTile();
            tile.AddItem(Instantiate(applePrefab).GetComponent<Item>());
        }
    }
}
