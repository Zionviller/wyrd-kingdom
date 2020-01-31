using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject worldMapPrefab;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera vcam;
    public Vector2Int mapSize;

    GameMap map;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(37);
        BeginGame();
    }

    void BeginGame()
    {
        map = Instantiate(worldMapPrefab).GetComponent<GameMap>();
        map.SetTileData(MapGenerator.RandomMap(mapSize));
        map.GrowApples(50);

        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<PlayerController>();
        player.actor.map = map;
        vcam.Follow = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            map.SetTileData(MapGenerator.RandomMap(mapSize));
        }
    }
}
