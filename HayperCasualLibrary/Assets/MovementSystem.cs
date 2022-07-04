using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        Movement.OnForwardMove += ForwardMove;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy()
    {
        Movement.OnForwardMove -= ForwardMove;
    }

    private void ForwardMove(Rigidbody playerRb, Transform player,int speed)
    {
        if (gameManager.isMoveWithVector3)
        {
            gameManager._forwardVelocity = Vector3.forward * speed * Time.deltaTime;
        }
        else
        {
            gameManager._forwardVelocity = player.forward * speed * Time.deltaTime;
        }
        
        if (!gameManager.isSwerveOpen)
        {
            playerRb.MovePosition(playerRb.position + gameManager._forwardVelocity);
        }
    }
}