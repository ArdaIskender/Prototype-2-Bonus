using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Movement Variables
    private float horizontalInput;
    private float verticalInput;
    private float playerMoveSpeed = 10f;
    private float playerMoveRangeX = 10f;
    private float playerMoveRangeZ = 15f;
    // Player Projectile
    public GameObject projectile;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * playerMoveSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playerMoveSpeed);
        // Limit the players movement range if they try to go out of the screen
        if (transform.position.x < -playerMoveRangeX)
        {
            transform.position = new Vector3(-playerMoveRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > playerMoveRangeX)
        {
            transform.position = new Vector3(playerMoveRangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.z > playerMoveRangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerMoveRangeZ);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }

    }

    void FireProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
