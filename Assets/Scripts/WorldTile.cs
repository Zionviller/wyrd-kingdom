using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public Vector2Int worldPos;
    public int worldY = 0;
    public TileType type = TileType.VOID;

    public Dictionary<TileType, Color> TileColors = new Dictionary<TileType, Color>
    {
        {TileType.VOID, new Color(0.0f, 0.0f, 0.0f, 0.0f) },
        {TileType.GRASS, new Color(0.2f,0.57f,0.13f) },
        {TileType.DESERT, new Color(0.96f,0.85f,0.63f) },
        {TileType.FOREST, new Color(0.23f,0.36f,0.16f) },
        {TileType.MOUNTAIN, new Color(0.67f,0.65f,0.76f) },
        {TileType.RIVER, new Color(0.63f,0.94f,0.93f) },
        {TileType.OCEAN, new Color(0.14f,0.11f,0.5f) },
        {TileType.ERROR, new Color(1.0f,0.0f,1.0f) },
    };

    public SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        UpdateSprite();
    }

    //private void OnValidate()
    //{
    //    UpdateSprite();
    //}

    public TileType GetTileType()
    {
        return type;
    }

    public void SetTileType(TileType type)
    {
        this.type = type;
        UpdateSprite(type);
    }

    void UpdateSprite(TileType type)
    {
        sr.color = TileColors[type];
    }

    void UpdateSprite()
    {
        sr.color = TileColors[type];
    }
}

public enum TileType
{
    VOID,
    OCEAN,
    GRASS,
    RIVER,
    FOREST,
    DESERT,
    MOUNTAIN,
    ERROR,
}

