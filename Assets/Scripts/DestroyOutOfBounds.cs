using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float horizontalBound = -20f;
    private float verticalBound = -7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < horizontalBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > -horizontalBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < verticalBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > 20f)
        {
            Destroy(gameObject);
        }
    }
}
