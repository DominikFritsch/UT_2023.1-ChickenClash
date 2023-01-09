using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveDown : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float force = 50.0f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.Rigidbody rb;
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        rb = gameObject.GetComponent<UnityEngine.Rigidbody>();
    }
    void FixedUpdate()
    {
        var direction = UnityEngine.Vector3.forward;
        rb.AddForce(direction * -force);
    }
    #endregion
}
