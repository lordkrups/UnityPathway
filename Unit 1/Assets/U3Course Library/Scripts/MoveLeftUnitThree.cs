using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftUnitThree : MonoBehaviour
{
    [SerializeField] private PlayerControllerUnitThree playerControllerUnitThree;
    [SerializeField] public float endOfTheLine = -15f;
    [SerializeField] public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerUnitThree = GameObject.Find("Player").GetComponent<PlayerControllerUnitThree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerUnitThree.GAME_OVER != true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if(transform.position.x <= endOfTheLine && gameObject.CompareTag("Obstacle")){
                Destroy(gameObject);
            }
        }
    }
}
