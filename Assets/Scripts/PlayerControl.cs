// Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    // public == can be changed from inspector
    public float speed = 0;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    // private == cannot be accessed from inspector
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int numCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        // Remember, rb will be the player object
        rb = GetComponent<Rigidbody>();

        // Number of collectible objects
        numCollectibles = 12;

        // Set score equal to 0
        count = 0;

        // Display score initially
        SetCountText();

		// Set victory message to disabled
		winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) // InputValue is the type; movementValue is the parameter
    {
        // Function body
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= numCollectibles)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called before frame
    // FixedUpdate is called last (after any physics calculations)
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // OnTriggerEnter: When collides, don't do any physics
    // "other" is the object (class Collision) that the player crashes into
    // Don't forget to add a rigid body and set "is kinematic"! disables forces but still allows animation due to its transform
    private void OnTriggerEnter(Collider other)
    {
        // Create a tag with a prefab
        // Don't forget to turn on trigger collider!
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Disable game object
            other.gameObject.SetActive(false);

            // Increase score
            count++;

            // Display score
            SetCountText();
        }
    }
}
