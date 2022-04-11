using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerUnitThree : MonoBehaviour
{
    [SerializeField] private PlayerControllerUnitThree playerControllerUnitThree;
    [SerializeField] public GameObject obstaclePrefab;
    [SerializeField] public GameObject spawnPos;
    [SerializeField] public float spawnDelay = 2f;
    [SerializeField] public float nextSpawnTime = 0f;
    [SerializeField] public float seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(obstaclePrefab, spawnPos.transform.position, obstaclePrefab.transform.rotation, spawnPos.transform);
        playerControllerUnitThree = GameObject.Find("Player").GetComponent<PlayerControllerUnitThree>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds > nextSpawnTime)
        {
            SpawnRandomAnimal();
            nextSpawnTime += spawnDelay;
        }
    }
    void SpawnRandomAnimal()
    {
        if (playerControllerUnitThree.GAME_OVER != true)
        {
            Instantiate(obstaclePrefab, spawnPos.transform.position, obstaclePrefab.transform.rotation, spawnPos.transform);
        }
        // Get a rando
        //float range = Random.Range(transform.position.x - xSpawnRange, transform.position.x + xSpawnRange);
    }
}
