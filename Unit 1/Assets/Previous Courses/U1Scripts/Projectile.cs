using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float topBoundry = 80f;
    [SerializeField] protected float botBoundry = -6f;
    [SerializeField] protected float leftBoundry = -14f;
    [SerializeField] protected float rightBoundry = 14f;
    [SerializeField] protected bool doneDamage = false;

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
    // What if it is a animal its' self
    protected virtual void OnTriggerEnter(Collider collider)
    { 

    }

}
