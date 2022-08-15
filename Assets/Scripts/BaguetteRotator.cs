using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaguetteRotator : MonoBehaviour
{
    public float rotationSpeed;
    void Update()
    {
		// Rotate can either take a Vector3 or three floats as an argument
		// deltaTime is the time in seconds since the last frame
		transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);	
    }
}
