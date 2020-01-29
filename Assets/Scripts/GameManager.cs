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
    MapView map;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
        map.GenerateMapView(mapSize);
    }

    private void OnValidate()
    {
        map.GenerateMapView(mapSize);
    }

    void BeginGame()
    {
        map = Instantiate(worldMapPrefab, Vector3.zero, Quaternion.identity).GetComponent<MapView>();
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<PlayerController>();
        player.actor.map = map;
        vcam.Follow = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
