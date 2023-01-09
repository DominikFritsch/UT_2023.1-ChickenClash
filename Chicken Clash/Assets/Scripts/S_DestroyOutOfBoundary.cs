using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DestroyOutOfBoundary : MonoBehaviour
{
    /* PRIVATE VARIABLES */
    #region
    private float minZBoundary = -15.0f;
    #endregion

    /* STANDARD METHODS */
    #region
    void Update()
    {
        if(gameObject.transform.position.z <= minZBoundary)
            UnityEngine.Object.Destroy(gameObject);
    }
    #endregion
}
