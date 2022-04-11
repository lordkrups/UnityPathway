using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampedeManager : MonoBehaviour
{
    [SerializeField] public WorldOrigin worldOrigin;
    public GameObject projectilesContainer;
    [SerializeField] public bool POINT_DOWN = false;
    [SerializeField] public float xSpawnRange = 20f;
    [SerializeField] public float spawnRate = 3f;
    [SerializeField] public float nextSpawnTime = 3f;
    [SerializeField] public float seconds = 0;

    public AnimalProjectile[] animalProjectilesArray;
    // Start is called before the first frame update
    void Start()
    {
        if (POINT_DOWN)
        {
            // Make a transform face up or down
            Vector3 currentEulerAngles = new Vector3(0f, 180f, 0f);
            transform.eulerAngles = currentEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds > nextSpawnTime)
        {
            SpawnRandomAnimal();
            nextSpawnTime += spawnRate;
        }
    }

    void SpawnRandomAnimal()
    {
        // Get a rando
        int animalIndex = Random.Range(0, animalProjectilesArray.Length);
        float range = Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange);
        // Stick in some range of the spawner, along the x axis
        Vector3 spawnPos = new Vector3(range, 0f, gameObject.transform.position.z);
        // Make a animal facing up or down 
        Instantiate(animalProjectilesArray[animalIndex], spawnPos, transform.rotation, projectilesContainer.transform.transform);
        // float zTopBound = transform.position.z;
        // float zBotBound = belowCameraSpawnBoundry.transform.position.z;
        // animalProjectilesArray[animalProjectilesArray.Length-1].SetTopBoundries(zTopBound);
        // animalProjectilesArray[animalProjectilesArray.Length-1].SetBotBoundries(zBotBound);
    }
}
