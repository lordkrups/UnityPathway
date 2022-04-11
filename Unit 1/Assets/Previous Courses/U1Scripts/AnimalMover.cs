using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] public WorldOrigin worldOrigin;
    [SerializeField] public float topBoundry = 80f;
    [SerializeField] public float botBoundry = -6f;
    [SerializeField] public float leftBoundry = -14f;
    [SerializeField] public float rightBoundry = 14f;
    [SerializeField] public bool doneDamage = false;

    public float speed = 4.0f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Do a move
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Am I out of bounds?
        if (transform.position.z < botBoundry)
        {
            // Die
            Destroy(gameObject);
        }
        if (transform.position.z > topBoundry)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBoundry)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > rightBoundry)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {

    }
}
