using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveDown : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float speed = 50.0f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.Rigidbody rb;
    float conversionFactor = 3.6f;
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        rb = gameObject.GetComponent<UnityEngine.Rigidbody>();       
    }
    void FixedUpdate()
    {
        rb.velocity = UnityEngine.Vector3.back * (speed / conversionFactor);
    }
    #endregion
}
