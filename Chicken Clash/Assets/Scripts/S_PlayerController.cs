using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float force = 10.0f;
    public float zBoundary = 10.6f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.Transform playerTransform;
    UnityEngine.Rigidbody playerRigidbody;
    #endregion

    /* METHODS */
    #region
    void HorizontalMovement()
    {
        var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        var direction = UnityEngine.Vector3.right;
        playerRigidbody.AddForce(direction * horizontalInput * force);
    }
    void VerticalMovement()
    {
        var verticalInput = UnityEngine.Input.GetAxis("Vertical");
        var direction = UnityEngine.Vector3.forward;
        playerRigidbody.AddForce(direction * verticalInput * force);
    }
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        playerTransform = gameObject.GetComponent<UnityEngine.Transform>();
        playerRigidbody = gameObject.GetComponent<UnityEngine.Rigidbody>();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        if(playerTransform.position.z >= zBoundary)
            playerTransform.position = new UnityEngine.Vector3(playerTransform.position.x, playerTransform.position.y, zBoundary);
        else
            VerticalMovement();

        if (playerTransform.position.z <= -zBoundary)
            playerTransform.position = new UnityEngine.Vector3(playerTransform.position.x, playerTransform.position.y, -zBoundary);
        else
            VerticalMovement();

        HorizontalMovement();
    }
    #endregion

}
