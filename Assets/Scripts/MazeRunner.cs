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
    public GameObject winTextObject;
    public TextMeshProUGUI startTextObject;
    public int totalPickups;
    public GameObject teleport;

    private Rigidbody rb;
    private Vector3 angularVelocity;
    private float movementX;
    private float movementY;
    private int score;
    private int stage;

    void Start()
    {
        // rigid body of self
        rb = GetComponent<Rigidbody>();

        // rotate about y-axis
        angularVelocity = new Vector3(0, angularSpeed, 0);

        // hide teleport object
        teleport.SetActive(false);

        // Initial display
        score = 0;
        stage = 1;
        SetScoreText();
        winTextObject.SetActive(false);
        StartCoroutine(ShowInstructions("Collect all baguettes!", 5));
    }

    // Display a temporary message
    IEnumerator ShowInstructions(string message, float delay)
    {
        startTextObject.text = message;
        startTextObject.enabled = true;
        yield return new WaitForSeconds(delay);
        startTextObject.enabled = false;
    }

    void SetScoreText()
    {
        // update score
        scoreText.text = "Stage: " + stage.ToString() + "\nScore: " + score.ToString() + "/" + totalPickups.ToString();
        if (score >= totalPickups)
        {
            winTextObject.SetActive(true);
            teleport.SetActive(true);
        }
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
        if (other.gameObject.CompareTag("Baguette"))
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
