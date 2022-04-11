using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalProjectile : AnimalMover
{
    [SerializeField] protected int damage = 1;
    [SerializeField] private int health = 2;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        base.worldOrigin = GetComponentInParent<WorldOrigin>();

        base.topBoundry += GetComponentInParent<WorldOrigin>().AheadOfPlayerBoundry.position.z;
        base.botBoundry = GetComponentInParent<WorldOrigin>().belowCameraSpawnBoundry.position.z;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter(Collider collider)
    {
        // PlayerHealthManager isItAPlayer = GetComponentInParent(typeof(PlayerHealthManager)) as PlayerHealthManager; ;

        if (collider.GetComponent<PlayerHealthManager>() != null && !doneDamage)
        {
            Debug.Log("hit the player");
            collider.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            this.doneDamage = true;
        }

        //Destroy(gameObject);
    }
}