using UnityEngine;

public class S_DestroyBecauseProjectile : MonoBehaviour
{
    /* STANDARD METHODS */
    #region
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            if (gameObject.CompareTag("Enemy"))
            {
                UnityEngine.GameObject.Destroy(gameObject);
                UnityEngine.GameObject.Destroy(other.gameObject);
            }        
            if (gameObject.CompareTag("Obstacle"))
            {
                UnityEngine.GameObject.Destroy(other.gameObject);
            }
        }
    }
    #endregion
}
