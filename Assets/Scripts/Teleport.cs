using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject target;
    public int offset;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = target.transform.position + (new Vector3(0, 0, offset));

            // play teleport sound
        }
    }
}
