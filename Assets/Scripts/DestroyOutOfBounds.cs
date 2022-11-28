using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float horizontalBound = -20f;
    private float verticalBound = -7f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < horizontalBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        if (transform.position.x > -horizontalBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        if (transform.position.z < verticalBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        if (transform.position.z > 20f)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}
