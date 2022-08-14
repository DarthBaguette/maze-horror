using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRunner : MonoBehaviour
{

    public float speed;
    public float angularSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            rb.MovePosition(transform.position - Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -angularSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, angularSpeed, 0);
        }

        Vector3 directions = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + directions * Time.deltaTime * speed);
    }
}
