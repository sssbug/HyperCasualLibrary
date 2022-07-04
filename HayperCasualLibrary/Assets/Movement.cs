using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    public static event Action<Rigidbody,Transform,int> OnForwardMove;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        ForwardMove();
    }

    private void ForwardMove()
    {
        if (gameManager.isMoveOpen)
        {
            OnForwardMove?.Invoke(this.GetComponent<Rigidbody>(), this.transform, gameManager.moveSpeed);
        }

    }
}