using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        Touch.OnSwerweTouch += Swerwe;
        Touch.OnSwipeTouch += Swipe;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy()
    {
        Touch.OnSwerweTouch -= Swerwe;
        Touch.OnSwipeTouch -= Swipe;
    }

    private void Swerwe(Rigidbody playerRb, Transform player)
    {

        if (Input.GetMouseButtonDown(0))
        {
            gameManager.lastFrameMousePosX = Input.mousePosition.x;


        }
        else if (Input.GetMouseButton(0))
        {
            float _inputDifference = Input.mousePosition.x - gameManager.lastFrameMousePosX;


            gameManager.swerveAmount = (_inputDifference * Time.fixedDeltaTime * gameManager.sensitivitySwerve);


            gameManager.lastFrameMousePosX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            gameManager.swerveAmount = 0;
        }

        if (gameManager.isSwerveWithVector3)
        {
            gameManager._horizontalVelocity = Vector3.right * gameManager.swerveAmount * gameManager.sensitivitySwerve;
        }
        else
        {
            gameManager._horizontalVelocity = player.right * gameManager.swerveAmount * gameManager.sensitivitySwerve;
        }



        if (gameManager.isMoveOpen)
        {
            if (gameManager._forwardVelocity != null)
            {
                playerRb.MovePosition(playerRb.position + gameManager._horizontalVelocity + gameManager._forwardVelocity);
            }
        }
        else
        {
            playerRb.MovePosition(playerRb.position + gameManager._horizontalVelocity);
        }

        if (gameManager.isTransformClampOpen)
        {
            float clamp = Mathf.Clamp(player.position.x, gameManager.minXTrans, gameManager.maxXTrans);
            player.position = new Vector3(clamp, player.position.y, player.position.z);
        }
        //if (gameManager.isRotationClamp)
        //{
        //    Vector3 playerAngles = player.transform.rotation.eulerAngles;
        //    playerAngles.y = (playerAngles.y > 180) ? playerAngles.y - 360 : playerAngles.y;
        //    playerAngles.y = Mathf.Clamp(playerAngles.y,gameManager.minYRot,gameManager.maxYRot);
        //    player.transform.rotation = Quaternion.Euler(playerAngles);
        //}
    }
    public void Swipe(Rigidbody playerRb, Transform player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            gameManager.firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            //create vector from the two points
            gameManager.currentSwipe = new Vector2(Input.mousePosition.x - gameManager.firstPressPos.x, Input.mousePosition.y - gameManager.firstPressPos.y);

            //normalize the 2d vector
            gameManager.currentSwipe.Normalize();

            //swipe upwards
            if (gameManager.currentSwipe.y > 0 && gameManager.currentSwipe.x > -0.5f && gameManager.currentSwipe.x < 0.5f)
            {
                //transform.position += transform.forward;
            }
            //swipe down
            if (gameManager.currentSwipe.y < 0 && gameManager.currentSwipe.x > -0.5f && gameManager.currentSwipe.x < 0.5f)
            {
                //Debug.Log("down swipe");
            }
            //swipe left
            if (gameManager.currentSwipe.x < 0 && gameManager.currentSwipe.y > -0.5f && gameManager.currentSwipe.y < 0.5f)
            {
                if (gameManager.isPosition)
                {
                    if (gameManager.isSwipeWithVector3)
                    {
                        if (gameManager.isMoveOpen)
                        {
                            if (gameManager._forwardVelocity != null)
                            {
                                gameManager._verticalVelocity = -Vector3.right * gameManager.swipeSpeed * Time.deltaTime;
                                playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity + gameManager._forwardVelocity);
                            }
                        }
                        else
                        {
                            gameManager._verticalVelocity = -Vector3.right * gameManager.swipeSpeed * Time.deltaTime;
                            playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity);
                        }
                                
                        
                    }
                    else
                    {
                        if (gameManager.isMoveOpen)
                        {
                            if (gameManager._forwardVelocity != null)
                            {
                                gameManager._verticalVelocity = -player.right * gameManager.swipeSpeed * Time.deltaTime;
                                playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity + gameManager._forwardVelocity);
                            }
                        }
                        else
                        {
                            gameManager._verticalVelocity = -player.right * gameManager.swipeSpeed * Time.deltaTime;
                            playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity);
                        }
                    }

                }
                if (gameManager.isRotation)
                {
                    gameManager.m_EulerAngleVelocity = new Vector3(0, -100, 0);
                    Quaternion deltaRotation = Quaternion.Euler(gameManager.m_EulerAngleVelocity * Time.fixedDeltaTime);
                    playerRb.MoveRotation(playerRb.rotation * deltaRotation);
                }

            }
            //swipe right
            if (gameManager.currentSwipe.x > 0 && gameManager.currentSwipe.y > -0.5f && gameManager.currentSwipe.y < 0.5f)
            {
                if (gameManager.isPosition)
                {
                    if (gameManager.isSwipeWithVector3)
                    {
                        if (gameManager.isMoveOpen)
                        {
                            if (gameManager._forwardVelocity != null)
                            {
                                gameManager._verticalVelocity = Vector3.right * gameManager.swipeSpeed * Time.deltaTime;
                                playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity + gameManager._forwardVelocity);
                                
                            }
                        }
                        else
                        {
                            gameManager._verticalVelocity = Vector3.right * gameManager.swipeSpeed * Time.deltaTime;
                            playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity);
                        }
                        
                    }
                    else
                    {
                        if (gameManager.isMoveOpen)
                        {
                            if (gameManager._forwardVelocity != null)
                            {
                                gameManager._verticalVelocity = player.right * gameManager.swipeSpeed * Time.deltaTime;
                                playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity + gameManager._forwardVelocity);
                            }
                        }
                        else
                        {
                            gameManager._verticalVelocity = player.right * gameManager.swipeSpeed * Time.deltaTime;
                            playerRb.MovePosition(playerRb.position + gameManager._verticalVelocity);
                        }
                        
                    }
                }
                if (gameManager.isRotation)
                {
                    gameManager.m_EulerAngleVelocity = new Vector3(0, 100, 0);
                    Quaternion deltaRotation = Quaternion.Euler(gameManager.m_EulerAngleVelocity * Time.fixedDeltaTime);
                    playerRb.MoveRotation(playerRb.rotation * deltaRotation);


                }

            }
        }
        if (gameManager.isTransformClampOpen)
        {
            float clamp = Mathf.Clamp(player.position.x, gameManager.minXTrans, gameManager.maxXTrans);
            player.position = new Vector3(clamp, player.position.y, player.position.z);
        }
        //if (gameManager.isRotationClamp)
        //{
        //    Vector3 playerAngles = player.transform.rotation.eulerAngles;
        //    playerAngles.y = (playerAngles.y > 180) ? playerAngles.y - 360 : playerAngles.y;
        //    playerAngles.y = Mathf.Clamp(playerAngles.y, gameManager.minYRot, gameManager.maxYRot);
        //    player.rotation = Quaternion.Euler(playerAngles);
            
        //}
    }
}