using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectile : Projectile
{
    [SerializeField] protected int damage = 1;
    [SerializeField] private int health = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
        AnimalProjectile isItAnimalProjectile = collider.GetComponent<AnimalProjectile>();

        if (isItAnimalProjectile != null && !doneDamage)
        {
            Debug.Log("hit an animal");
            isItAnimalProjectile.TakeDamage(damage);
            doneDamage = true;
            TakeDamage(1);
        }
    }
}
