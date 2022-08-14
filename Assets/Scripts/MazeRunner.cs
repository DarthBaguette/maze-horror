using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeRunner : MonoBehaviour
{

    public float speed;
    public float angularSpeed;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //void FixedUpdate()
    //{
    //    Vector3 translation = new Vector3(movementX, 0.0f, movementY);
    //    rb.AddForce(translation * speed);

    //    float turn = Input.GetAxis("Horizontal");
    //    rb.AddTorque(turn * angularSpeed * transform.up);
    //}

    //Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(Input.GetAxis("Horizontal") * angularSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(Input.GetAxis("Horizontal") * angularSpeed * Vector3.down);
        }
    }
}
