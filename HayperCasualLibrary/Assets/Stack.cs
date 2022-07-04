using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static event Action<Transform> OnStack;
    public static event Action<Transform> OnFormation;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    private void Update()
    {
        Stackk();
        Formation();
    }

    private void Stackk()
    {
        if (gameManager.isVerticalStackOpen)
        {
            OnStack?.Invoke(this.transform);
        }
        if (gameManager.isHorizontalStackOpen)
        {
            OnStack?.Invoke(this.transform);
        }
    }
    
    private void Formation()
    {
        if (gameManager.isFormationOpen)
        {
            OnFormation?.Invoke(this.transform);
        }
    }
    
}