using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StackSystem : MonoBehaviour
{
    private GameManager gameManager;

   
    Vector3 newStackPosition;
    void Start()
    {
        Stack.OnStack += StackMechanic;
        Stack.OnFormation += Formation;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy()
    {
        Stack.OnStack -= StackMechanic;
        Stack.OnFormation -= Formation;

    }

    private void StackMechanic(Transform player)
    {
        if (gameManager.VerticalStackableObject.Count != 0)
        {
            if (gameManager.isVerticalStackOpen)
            {
                gameManager.VerticalStackableObject[0].transform.position = gameManager.VerticalStackPosition + player.position;
                for (int i = 1; i < gameManager.VerticalStackableObject.Count; i++)
                {
                    if (gameManager.verticalStackIntoStackOpen)
                    {
                        if (i % gameManager.stackIntoStack != 0)
                        {
                            if (gameManager.VerticalStackableObject[i] != null)
                            {


                                gameManager.VerticalStackableObject[i].transform.position =
                                gameManager.VerticalStackableObject[i - 1].transform.position +
                                gameManager.VerticalOffset;

                            }

                        }
                        else
                        {

                            if (gameManager.VerticalStackableObject[i] != null)
                            {


                                if (i != gameManager.stackIntoStack)
                                {
                                    if (gameManager.x)
                                    {
                                        gameManager.VerticalStackableObject[i].transform.position =
                                        new Vector3(
                                        player.position.x + newStackPosition.x + gameManager.stackIntoStackPosition.x,
                                        player.position.y + gameManager.VerticalStackPosition.y + gameManager.stackIntoStackPosition.y,
                                        player.position.z + gameManager.VerticalStackPosition.z + gameManager.stackIntoStackPosition.z);

                                    }
                                    else if (gameManager.z)
                                    {
                                        gameManager.VerticalStackableObject[i].transform.position =
                                        new Vector3(
                                        player.position.x + gameManager.VerticalStackPosition.x + gameManager.stackIntoStackPosition.x,
                                        player.position.y + gameManager.VerticalStackPosition.y + gameManager.stackIntoStackPosition.y,
                                        newStackPosition.z + gameManager.stackIntoStackPosition.z);

                                    }

                                    newStackPosition = gameManager.VerticalStackableObject[i].transform.position;
                                }
                                else
                                {
                                    gameManager.VerticalStackableObject[i].transform.position =
                                    player.position + gameManager.VerticalStackPosition + gameManager.stackIntoStackPosition;
                                    newStackPosition = gameManager.VerticalStackableObject[i].transform.position;
                                }

                            }
                        }

                    }
                    else
                    {

                        if (gameManager.VerticalStackableObject[i] != null)
                        {
                            gameManager.VerticalStackableObject[i].transform.position =
                            gameManager.VerticalStackableObject[i - 1].transform.position +
                            gameManager.VerticalOffset;

                        }
                    }
                }

            }

            if (gameManager.isHorizontalStackOpen)
            {
                //gameManager.VerticalStackableObject[0].transform.position = Vector3.Lerp(gameManager.VerticalStackableObject[0].transform.position,
                //gameManager.HorizontalStackPosition + player.position, 30f * Time.deltaTime);

                gameManager.VerticalStackableObject[0].transform.position = new Vector3(
                Mathf.Lerp(gameManager.VerticalStackableObject[0].transform.position.x, player.position.x, 0.6f)
                , player.position.y + gameManager.HorizontalStackPosition.y
                , player.position.z + gameManager.HorizontalStackPosition.z);


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
    }

    private void Formation(Transform player)
    {
        TriangleFormation(player);
    }
    private void TriangleFormation(Transform player)
    {


        if (gameManager.container != null)
        {
            gameManager.container.transform.position = player.position;
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPosition = Vector3.left;
            if (gameManager.trianglesList.Count == 0)
            {
                gameManager.container = new GameObject("Container");
                gameManager.container.transform.parent = player.transform;
            }
           
            int rows = 10;

            float rowOffset = -0.5f;
            
            float xOffset = 1.1f;

            float zOffset = -1.1f;
            if (gameManager.trianglesList.Count == 0)
            {
                for (int i = 1; i <= rows; i++)
                {

                    for (int j = 0; j < i; j++)
                    {
                        targetPosition = new Vector3(targetPosition.x + xOffset, player.position.y, targetPosition.z);
                    }

                    targetPosition = new Vector3((rowOffset * i) - 1.0f, player.position.y, targetPosition.z + zOffset);
                    gameManager.trianglesList.Add(targetPosition);

                }
            }
            

            GameObject instance = Instantiate(gameManager.trianglePrefab);
            
            instance.transform.position = gameManager.trianglesList[0];
            instance.transform.parent = player.transform;

        }
    }
}