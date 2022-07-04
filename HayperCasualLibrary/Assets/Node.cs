using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Node : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject target;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManager.isHorizontalStackOpen)
        {
            if (target != null)
            {
                //transform.position = Vector3.Lerp(transform.position, target.transform.position + gameManager.HorizontalOffset, 10f * Time.deltaTime);
                transform.position = new Vector3(
               Mathf.Lerp(transform.position.x, target.transform.position.x, 0.6f)
               , target.transform.position.y + gameManager.HorizontalOffset.y
               , target.transform.position.z + gameManager.HorizontalOffset.z);
            }
            if (gameManager.VerticalStackableObject.Count >= 2)
            {
                if (gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1].GetComponent<Node>() != null)
                {
                    gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1].GetComponent<Node>().target =
                    gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 2];
                }
            }
           
        }

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
        if (other.gameObject.layer == 8)
        {
            if (gameManager.isVerticalStackOpen)
            {
                Destroy(gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1]);
                gameManager.VerticalStackableObject.Remove(gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1]);
            }
            if (gameManager.isHorizontalStackOpen)
            {
                Destroy(gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1]);
                gameManager.VerticalStackableObject.Remove(gameManager.VerticalStackableObject[gameManager.VerticalStackableObject.Count - 1]);
            }
        }
    }
}
