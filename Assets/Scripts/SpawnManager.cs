using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject farmer;


    private float spawnRangeX = 10f;
    private float spawnPosZ = 19f;
    private float spawnStartDelay = 3f;

    private float sideSpawnMinZ = 5f;
    private float sideSpawnMaxZ = 15f;
    private float sideSpawnX = 16f;

    private float difficultyCatalizor = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomAnimal", spawnStartDelay);
        Invoke("SpawnRightAnimal", spawnStartDelay+3f);
        Invoke("SpawnLeftAnimal", spawnStartDelay+6f);
        Invoke("SpawnFarmerLeft", spawnStartDelay+10f);
        Invoke("SpawnFarmerRight", spawnStartDelay+20f);
        Invoke("SpawnFarmerTop", spawnStartDelay+35f);
    }

    // Update is called once per frame
    void Update()
    {
        if (difficultyCatalizor >= 0.15f)
        {
            difficultyCatalizor -= 0.0055f * Time.deltaTime;
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 rotation = new Vector3(0,180,0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));

        float randomDelay = Random.Range(4f, 10f)* difficultyCatalizor;
        Debug.Log(randomDelay);
        Invoke("SpawnRandomAnimal", randomDelay);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));

        float randomDelay = Random.Range(4f, 10f) * difficultyCatalizor;
        Invoke("SpawnLeftAnimal", randomDelay);
    }
    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation)) ;

        float randomDelay = Random.Range(4f, 10f) * difficultyCatalizor;
        Invoke("SpawnRightAnimal", randomDelay);
    }

    void SpawnFarmerRight()
    {
        
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(farmer, spawnPos, Quaternion.Euler(rotation));

        float randomDelay = Random.Range(16f, 24f) * difficultyCatalizor;
        Invoke("SpawnFarmerRight", randomDelay);
    }

    void SpawnFarmerLeft()
    {

        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(farmer, spawnPos, Quaternion.Euler(rotation));

        float randomDelay = Random.Range(16f, 24f) * difficultyCatalizor;
        Invoke("SpawnFarmerLeft", randomDelay);
    }

    void SpawnFarmerTop()
    {

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 rotation = new Vector3(0, 180, 0);
        Instantiate(farmer, spawnPos, Quaternion.Euler(rotation));

        float randomDelay = Random.Range(16f, 24f) * difficultyCatalizor;
        Invoke("SpawnFarmerTop", randomDelay);
    }
}
