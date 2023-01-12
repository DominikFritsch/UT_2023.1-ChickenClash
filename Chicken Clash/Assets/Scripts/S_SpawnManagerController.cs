using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnManagerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public UnityEngine.GameObject[] prefabEnemies;
    public UnityEngine.GameObject prefabPowerup;
    public UnityEngine.GameObject prefabEgg;
    public UnityEngine.GameObject prefabProjectile;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.GameObject gameObjectEnemies;
    UnityEngine.GameObject gameObjectPowerups;
    UnityEngine.GameObject gameObjectEggs;
    UnityEngine.GameObject gameObjectProjectiles;
    UnityEngine.GameObject gameObjectPlayer;

    float xSpawnRange = 18.0f;
    float ySpawnValue = 1.05f;
    float zSpawnRange = 9.5f;
    float zSpawnValue = 15.0f;
    float startDelay = 1.0f;
    float repeatRateEnemy = 3.0f;
    float repeatRatePowerup = 10.0f;
    float projectileOffset = 1.4f;
    #endregion

    /* METHODS */
    #region
    void SpawnRandomEnemies()
    {
        var index = UnityEngine.Random.Range(0,prefabEnemies.Length);
        var original = prefabEnemies[index];
        var xPositionValue = UnityEngine.Random.Range(-xSpawnRange,xSpawnRange);
        var yPositionValue = ySpawnValue;
        var zPositionValue = zSpawnValue;
        var position = new UnityEngine.Vector3(xPositionValue,yPositionValue,zPositionValue);
        var rotation = original.transform.rotation;
        var parent = gameObjectEnemies.transform;

        UnityEngine.Object.Instantiate(original, position, rotation, parent);
    }
    void SpawnPowerup()
    {
        var original = prefabPowerup;
        var xPositionValue = UnityEngine.Random.Range(-xSpawnRange, xSpawnRange);
        var yPositionValue = ySpawnValue;
        var zPositionValue = UnityEngine.Random.Range(-zSpawnRange, zSpawnRange);
        var position = new UnityEngine.Vector3(xPositionValue, yPositionValue, zPositionValue);
        var rotation = original.transform.rotation;
        var parent = gameObjectPowerups.transform;

        UnityEngine.Object.Instantiate(original, position, rotation, parent);
    }
    public void SpawnEgg(float x, float y, float z)
    {
        if(z <= zSpawnRange && z >= -zSpawnRange)
        {
            var original = prefabEgg;
            var xPositionValue = x;
            var yPositionValue = y;
            var zPositionValue = z;
            var position = new UnityEngine.Vector3(xPositionValue, yPositionValue, zPositionValue);
            var rotation = original.transform.rotation;
            var parent = gameObjectEggs.transform;

            UnityEngine.Object.Instantiate(original, position, rotation, parent);
        }
    }

    public void SpawnProjectile()
    {
        var original = prefabProjectile;
        var xPositionValue = gameObjectPlayer.transform.position.x;
        var yPositionValue = gameObjectPlayer.transform.position.y;
        var zPositionValue = gameObjectPlayer.transform.position.z + projectileOffset;
        var position = new UnityEngine.Vector3(xPositionValue, yPositionValue, zPositionValue);
        var rotation = original.transform.rotation;
        var parent = gameObjectProjectiles.transform;

        UnityEngine.Object.Instantiate(original, position, rotation, parent);
    }

    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        // Find empty placeholder gameobjects
        gameObjectEnemies = UnityEngine.GameObject.Find("Enemies");
        gameObjectPowerups = UnityEngine.GameObject.Find("Powerups");
        gameObjectEggs = UnityEngine.GameObject.Find("Eggs");
        gameObjectProjectiles = UnityEngine.GameObject.Find("Projectiles");
        gameObjectPlayer = UnityEngine.GameObject.Find("Player");

        InvokeRepeating("SpawnRandomEnemies", startDelay, repeatRateEnemy);
        InvokeRepeating("SpawnPowerup", startDelay, repeatRatePowerup);
    }
    void Update()
    {

    }
    #endregion


}
