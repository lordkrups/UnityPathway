using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarController : MonoBehaviour
{
    [SerializeField] private float speedModifier = 10f;
    [SerializeField] private float turnSpeed = 10f;
    private float forwardInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get some controls input
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speedModifier * forwardInput);
        // Rotate the vehical
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
