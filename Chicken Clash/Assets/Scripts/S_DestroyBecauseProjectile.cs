using UnityEngine;

public class S_DestroyBecauseProjectile : MonoBehaviour
{
    /* PRIVATE VARIABLES */
    #region
    UnityEngine.GameObject gameObjectSpawnManager;
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        gameObjectSpawnManager = UnityEngine.GameObject.Find("SpawnManager");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            if (gameObject.CompareTag("Enemy"))
            {
                var xPositionEnemy = gameObject.transform.position.x;
                var yPositionEnemy = gameObject.transform.position.y;
                var zPositionEnemy = gameObject.transform.position.z;
                UnityEngine.GameObject.Destroy(gameObject);
                UnityEngine.GameObject.Destroy(other.gameObject);
                gameObjectSpawnManager.GetComponent<S_SpawnManagerController>().SpawnEgg(xPositionEnemy,yPositionEnemy,zPositionEnemy);
            }
        }
    }
    #endregion
}
