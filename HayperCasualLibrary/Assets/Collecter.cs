using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.layer = 7;

            if (gameManager.isVerticalStackOpen)
            {
                gameManager.VerticalStackableObject.Add(other.gameObject);
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<Node>();

            }
            if (gameManager.isHorizontalStackOpen)
            {

                gameManager.VerticalStackableObject.Add(other.gameObject);
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<Node>();
            }
        }


    }
}
