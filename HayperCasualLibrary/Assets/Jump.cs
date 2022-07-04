using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Jump : MonoBehaviour
{
    public static event Action<Transform, Rigidbody, Collider> OnJump;
    //public static event Action<Transform> OnHorizontalStack;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Jumping()
    {
        if (gameManager.isJumpOpen)
        {
            OnJump?.Invoke(this.transform, this.GetComponent<Rigidbody>(), this.GetComponent<Collider>());
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Jumping();
        }

    }

}
