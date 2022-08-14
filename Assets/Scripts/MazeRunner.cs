using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MazeRunner : MonoBehaviour
{

    public float speed;
    public float angularSpeed;
    public TextMeshProUGUI scoreText;
    public int totalPickups;

    private Rigidbody rb;
    private Vector3 angularVelocity;
    private float movementX;
    private float movementY;
    private int score, stage;

    void Start()
    {
        // rigid body of self
        rb = GetComponent<Rigidbody>();

        // rotate about y-axis
        angularVelocity = new Vector3(0, angularSpeed, 0);

        // Display results initially
        score = 0;
        stage = 1;
        SetScoreText();
    }

    void SetScoreText()
    {
        // update score
        scoreText.text = "Stage: " + stage.ToString() + "\nScore: " + score.ToString() + "/" + totalPickups.ToString();
    }

    void FixedUpdate()
    {
        // transform locally
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + rb.transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + -rb.transform.forward * Time.deltaTime * speed);
        }

        // Rotate about y-axis
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion deltaRotation = Quaternion.Euler(-angularVelocity * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("loafBaguette"))
        {
            // Disable contacted object
            other.gameObject.SetActive(false);

            // Increase score
            score++;

            // Update score text
            SetScoreText();
        }
    }
}
