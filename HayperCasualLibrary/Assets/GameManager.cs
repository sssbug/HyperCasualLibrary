using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    
    [Header("Clamp")]
    [Space(50)]

    public float minXTrans;
    public float maxXTrans;
    public bool isTransformClampOpen;
    //public float minYRot;
    //public float maxYRot;
    //public bool isRotationClamp;
    




    [Header("Movement")]
    [Space(50)]

    public int moveSpeed;
    public bool isMoveWithVector3;
    public bool isMoveOpen;
    [HideInInspector] public Vector3 _forwardVelocity;
    




    [Header("Jump")]
    [Space(50)]
    public int jumpPower;
    public bool isJumpOpen;
    




    [Header("TouchSwerve")]
    [Space(50)]

    public bool isSwerveWithVector3;
    public float sensitivitySwerve;
    public bool isSwerveOpen;
    [HideInInspector] public float lastFrameMousePosX;
    [HideInInspector] public float swerveAmount;
    [HideInInspector] public Vector3 _horizontalVelocity;
    




    [Header("TouchSwipe")]
    [Space(50)]

    public float swipeSpeed;
    public bool isSwipeWithVector3;
    public bool isPosition;
    public bool isRotation;
    public bool isSwipeOpen;
    [HideInInspector] public Vector3 m_EulerAngleVelocity;
    [HideInInspector] public Vector3 _verticalVelocity;
    [HideInInspector] public Vector2 firstPressPos;
    [HideInInspector] public Vector2 currentSwipe;
    




    [Header("TouchDragAndDrop")]
    [Space(50)]

    public GameObject selectObject = null;
    public bool isDragAndDropOpen;
    [HideInInspector] public float CameraZDistance;
    [HideInInspector] public Vector3 mousePosition;
    



     
    [Header("Stack")]
    [Space(50)]

    public Vector3 VerticalStackPosition;
    public Vector3 VerticalOffset;

    public int stackIntoStack;
    public Vector3 stackIntoStackPosition;
    public bool x, z;
    public bool verticalStackIntoStackOpen;

    public List<Vector3> trianglesList = new List<Vector3>();
    public GameObject trianglePrefab;
    public bool isFormationOpen;
    public List<GameObject> VerticalStackableObject = new List<GameObject>();
    public bool isVerticalStackOpen;
    [HideInInspector] public bool isTheTimeCome = true;
    [HideInInspector] public GameObject container; 




    [Header("HorizontalStack")]
    [Space(50)]

    public Vector3 HorizontalStackPosition;
    public Vector3 HorizontalOffset;
    public bool isHorizontalStackOpen;
    

}