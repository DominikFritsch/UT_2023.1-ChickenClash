using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnManagerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public UnityEngine.GameObject[] prefabEnemies;
    public UnityEngine.GameObject prefabObstacle;
    public UnityEngine.GameObject prefabPowerup;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.GameObject gameObjectEnemies;
    UnityEngine.GameObject gameObjectObstacles;
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
    float repeatRateObstacle = 10.0f;
    float repeatRatePowerup = 10.0f;
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
    void SpawnObstacle()
    {
        var original = prefabObstacle;
        var xPositionValue = UnityEngine.Random.Range(-xSpawnRange, xSpawnRange);
        var yPositionValue = ySpawnValue;
        var zPositionValue = zSpawnValue;
        var position = new UnityEngine.Vector3(xPositionValue, yPositionValue, zPositionValue);
        var rotation = original.transform.rotation;
        var parent = gameObjectObstacles.transform;

        UnityEngine.Object.Instantiate(original, position, rotation, parent);
    }
    void SpawnPowerup()
    {

    }
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        // Find empty placeholder gameobjects
        gameObjectEnemies = UnityEngine.GameObject.Find("Enemies");
        gameObjectObstacles = UnityEngine.GameObject.Find("Obstacles");
        gameObjectPowerups = UnityEngine.GameObject.Find("Powerups");
        gameObjectEggs = UnityEngine.GameObject.Find("Eggs");
        gameObjectProjectiles = UnityEngine.GameObject.Find("Projectiles");
        gameObjectPlayer = UnityEngine.GameObject.Find("Player");

        InvokeRepeating("SpawnRandomEnemies", startDelay, repeatRateEnemy);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRateObstacle);
    }
    void Update()
    {

    }
    #endregion


}
