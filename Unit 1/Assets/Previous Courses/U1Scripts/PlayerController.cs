using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField] public WorldOrigin worldOrigin;
    [SerializeField] public ProjectilesSpawner projectilesSpawner;
    [SerializeField] private float speedModifier = 10f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float topBoundry = 3f;
    [SerializeField] private float botBoundry = -11f;
    [SerializeField] private float leftBoundry = -12f;
    [SerializeField] private float rightBoundry = 12f;
    private float forwardInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {        
        topBoundry = transform.position.z + topBoundry;
        botBoundry = worldOrigin.belowCameraSpawnBoundry.transform.position.z;
        leftBoundry = transform.position.x + leftBoundry;
        rightBoundry = transform.position.x + rightBoundry;
    }

    // Update is called once per frame
    void Update()
    {
        // Get some controls input
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        doAmove();

        didAPress();
        // Rotate the vehical
        // transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

    void doAmove()
    {
        if (transform.position.z < botBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, botBoundry);
        }
        if (transform.position.z > topBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBoundry);
        }
        if (transform.position.x < leftBoundry)
        {
            transform.position = new Vector3(leftBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightBoundry)
        {
            transform.position = new Vector3(rightBoundry, transform.position.y, transform.position.z);
        }
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speedModifier * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speedModifier * horizontalInput);
    }

    void didAPress()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectilesSpawner.makeProjectile();
        }
    }
}
