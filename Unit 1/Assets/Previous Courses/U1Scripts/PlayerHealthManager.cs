using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(int dmg)
    {
        playerHealth -= dmg;
        Debug.Log("player hit for: " + dmg.ToString());
        Debug.Log("playerHealth is: " + playerHealth.ToString());
        AmIDead();
    }

    void AmIDead()
    {
        if (playerHealth <= 0)
        {
            //Destroy(gameObject);
        Debug.Log("GAME OVER");

        }
    }
}
