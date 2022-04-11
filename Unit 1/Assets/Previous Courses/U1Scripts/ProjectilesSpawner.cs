using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField] public WorldOrigin worldOrigin;
    [SerializeField] public Transform spawnPoint;
    public GameObject projectilesContainer;
    public FoodProjectile[] foodProjectilesArray;
    [SerializeField] public bool canShoot = true;
    [SerializeField] public float spawnRate = 3f;
    [SerializeField] public float nextSpawnTime = 3f;
    [SerializeField] public float seconds = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void makeProjectile()
    {
        if (canShoot)
        {
            canShoot = false;

            int foodIndex = Random.Range(0, foodProjectilesArray.Length);

            Instantiate(foodProjectilesArray[0], spawnPoint.position, projectilesContainer.transform.rotation, projectilesContainer.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds > nextSpawnTime)
        {
            canShoot = true;
            nextSpawnTime += spawnRate;
        }
    }
}
