using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && gameObject.tag == "Animal")
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
            
        }
        if (other.gameObject.tag == "Animal" && gameObject.tag == "Animal")
        {
            
        }
        if (other.gameObject.tag == "Animal" && gameObject.tag == "Projectile")
        {
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Farmer" && gameObject.tag == "Projectile")
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
