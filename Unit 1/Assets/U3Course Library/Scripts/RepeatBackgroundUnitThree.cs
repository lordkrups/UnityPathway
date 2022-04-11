using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundUnitThree : MonoBehaviour
{
    [SerializeField] private PlayerControllerUnitThree playerControllerUnitThree;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public float repeatWidth;
    [SerializeField] public float repeatWidthh;
    [SerializeField] public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerUnitThree = GameObject.Find("Player").GetComponent<PlayerControllerUnitThree>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        repeatWidthh = startPos.x - repeatWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerUnitThree.GAME_OVER != true)
        {
            if (transform.position.x <= startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
