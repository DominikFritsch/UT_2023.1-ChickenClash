using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float force = 15.0f;
    public float zBoundary = 10.6f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.Transform playerTransform;
    UnityEngine.Rigidbody playerRigidbody;
    #endregion

    /* METHODS */
    #region
    // Moves the player in all directions based on horizontal and vertical input
    void MovePlayer()
    {
        var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        var verticalInput = UnityEngine.Input.GetAxis("Vertical");

        // Horizontal movement
        var direction = UnityEngine.Vector3.right;
        playerRigidbody.AddForce(direction * horizontalInput * force);

        // Vertical movement
        direction = UnityEngine.Vector3.forward;
        playerRigidbody.AddForce(direction * verticalInput * force);
    }
    // Prevent the player from leaving the top or bottom
    void ConstrainPlayerPosition()
    {
        if (playerTransform.position.z >= zBoundary)
            playerTransform.position = new UnityEngine.Vector3(playerTransform.position.x, playerTransform.position.y, zBoundary);
        if (playerTransform.position.z <= -zBoundary)
            playerTransform.position = new UnityEngine.Vector3(playerTransform.position.x, playerTransform.position.y, -zBoundary);
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
        MovePlayer();
        ConstrainPlayerPosition();
    }
    #endregion

}
