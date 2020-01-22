using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject worldMapPrefab;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera vcam;
    WorldMap map;
    PlayerController player; 

    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
        map.GenerateMap();
    }

    void BeginGame()
    {
        map = Instantiate(worldMapPrefab, Vector3.zero, Quaternion.identity).GetComponent<WorldMap>();
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<PlayerController>();
        player.actor.map = map;
        vcam.Follow = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
