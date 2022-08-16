using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandTime : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayGrowl", 7);
    }

    void PlayGrowl()
    {
        audioSource.Play();

        float randomTime = Random.Range(7, 25);

        Invoke("PlayGrowl", randomTime);
    }

}
