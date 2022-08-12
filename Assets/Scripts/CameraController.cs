using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    
    void Start()
    {
		// Sets offset = [camera position] - [player position]
		offset = transform.position - player.transform.position;    
    }

	// there are many update functions that could change player position (e.g., physics)
	// LateUpdate ensures that camera transform occurs after all these updates
    void LateUpdate()
    {
		transform.position = player.transform.position + offset;
    }
}
