using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DestroyOutOfBoundary : MonoBehaviour
{
    /* PRIVATE VARIABLES */
    #region
    public float zBoundaryValue = 15.0f;
    #endregion

    /* STANDARD METHODS */
    #region
    void Update()
    {
        if(gameObject.CompareTag("Projectile"))
        {
            if (gameObject.transform.position.z >= zBoundaryValue)
                UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            if (gameObject.transform.position.z <= zBoundaryValue)
                UnityEngine.Object.Destroy(gameObject);
        }
    }
    #endregion
}
