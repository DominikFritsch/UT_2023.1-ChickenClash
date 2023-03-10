using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    #region
    public float force = 15.0f;
    public float zBoundary = 10.6f;
    #endregion

    /* PRIVATE VARIABLES */
    #region
    UnityEngine.GameObject gameObjectSpawnManager;
    UnityEngine.Rigidbody rb;
    #endregion

    /* METHODS */
    #region
    // Moves the player in all directions based on horizontal and vertical input
    void MovePlayer()
    {
        var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        var verticalInput = UnityEngine.Input.GetAxis("Vertical");

        // Horizontal movement
        var direction = UnityEngine.Vector3.right;
        rb.AddForce(direction * horizontalInput * force);

        // Vertical movement
        direction = UnityEngine.Vector3.forward;
        rb.AddForce(direction * verticalInput * force);
    }
    // Prevent the player from leaving the top or bottom
    void ConstrainPlayerPosition()
    {
        if (gameObject.transform.position.z >= zBoundary)
            gameObject.transform.position = new UnityEngine.Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zBoundary);
        if (gameObject.transform.position.z <= -zBoundary)
            gameObject.transform.position = new UnityEngine.Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -zBoundary);
    }
    #endregion

    /* STANDARD METHODS */
    #region
    void Start()
    {
        gameObjectSpawnManager = UnityEngine.GameObject.Find("SpawnManager");
        rb = gameObject.GetComponent<UnityEngine.Rigidbody>();
    }
    void Update()
    {
        ConstrainPlayerPosition();

        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
            gameObjectSpawnManager.GetComponent<S_SpawnManagerController>().SpawnProjectile();
    }
    void FixedUpdate()
    {
        MovePlayer();

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
            UnityEngine.Debug.Log("Player has collided with environment.");
        else if (collision.gameObject.CompareTag("Enemy"))
            UnityEngine.Debug.Log("Player has collided with an enemy.");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            UnityEngine.Debug.Log("Player has collided with a powerup.");
            UnityEngine.Object.Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Egg"))
        {
            UnityEngine.Debug.Log("Player has collided with an egg.");
            UnityEngine.Object.Destroy(other.gameObject);
        }
    }
    #endregion

}
