using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapAndDropSystem : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start()
    {
        GrapAndDrop.OnDragAndDrop += DragAndDroping;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnDestroy()
    {
        GrapAndDrop.OnDragAndDrop -= DragAndDroping;
    }

    private void DragAndDroping(Rigidbody playerRb, Transform player)
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.selectObject == null)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.layer != 9)
                    {
                        return;
                    }
                    else
                    {
                        gameManager.selectObject = hit.collider.gameObject;
                    }
                    Debug.Log("d");

                    return;
                    
                }

            }
           
            

        }
        if (Input.GetMouseButton(0))
        {
            if (gameManager.selectObject)
            {
                gameManager.mousePosition =
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameManager.CameraZDistance); //z axis added to screen point 
                Vector3 NewWorldPosition =
                    Camera.main.ScreenToWorldPoint(gameManager.mousePosition); //Screen point converted to world point

                gameManager.selectObject.transform.position = NewWorldPosition;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
                                                    
            gameManager.selectObject = null;
        }
    }
}