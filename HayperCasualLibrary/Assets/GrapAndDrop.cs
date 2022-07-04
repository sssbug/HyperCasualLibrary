using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapAndDrop : MonoBehaviour
{
    public static event Action<Rigidbody, Transform> OnDragAndDrop;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        TouchDragAndDrop();
    }
    private void TouchDragAndDrop()
    {
        if (gameManager.isDragAndDropOpen)
        {
            OnDragAndDrop?.Invoke(this.GetComponent<Rigidbody>(), this.transform);
        }
    }
}
