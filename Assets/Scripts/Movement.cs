using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustVelocity;
    [SerializeField] float rotationVelocity;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustVelocity * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationVelocity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationVelocity);
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation  so we can manually rotate;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation  so that gravity works;
    }
}
