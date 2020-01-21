using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class PlayerController : MonoBehaviour
{
    Actor actor;

    private void Awake()
    {
        actor = gameObject.GetComponent<Actor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            actor.MoveActor(Vector3Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            actor.MoveActor(Vector3Int.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            actor.MoveActor(Vector3Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            actor.MoveActor(Vector3Int.left);
        }


    }
}
