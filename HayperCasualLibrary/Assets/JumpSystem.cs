using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        Jump.OnJump += JumpMechanic;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy()
    {
        Jump.OnJump -= JumpMechanic;
    }

    private void JumpMechanic(Transform player,Rigidbody rig, Collider coll)
    {
        
        if (rig.isKinematic !=  false)
        {
            rig.isKinematic = false;
            rig.useGravity = true;
            
        }
        rig.velocity = new Vector3(0,gameManager.jumpPower,0);
    }
}