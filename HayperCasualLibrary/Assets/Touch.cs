using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static event Action<Rigidbody,Transform> OnSwerweTouch;
    public static event Action<Rigidbody, Transform> OnSwipeTouch;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        TouchSwerwe();
        TouchSwipe();
    }

    private void TouchSwerwe()
    {
        if (gameManager.isSwerveOpen)
        {
            OnSwerweTouch?.Invoke(this.GetComponent<Rigidbody>(),this.transform);
        }
    }

    private void TouchSwipe()
    {
        if (gameManager.isSwipeOpen)
        {
            OnSwipeTouch?.Invoke(this.GetComponent<Rigidbody>(), this.transform);
        }
    }

   
}