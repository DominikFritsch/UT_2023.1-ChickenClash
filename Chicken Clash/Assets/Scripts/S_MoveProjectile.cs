using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveProjectile : MonoBehaviour
{
    /* PRIVATE VARIABLES */
    #region
    float speed = 25.0f;
    #endregion

    /* STANDARD METHODS */
    #region
    void Update()
    {
        var direction = UnityEngine.Vector3.forward;
        var frameFactor = UnityEngine.Time.deltaTime;
        gameObject.transform.Translate(direction * speed * frameFactor);
    }
    #endregion
}
