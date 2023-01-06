using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float force = 10.0f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
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
        playerRigidbody = gameObject.GetComponent<UnityEngine.Rigidbody>();
    }
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }
    #endregion

}
