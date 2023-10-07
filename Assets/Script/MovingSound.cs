using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingSound : MonoBehaviour
{
    public AudioSource audioSource;

    public float minmove = 0.1f;
    private Vector3 previousPos;

    void Start()
    {
        previousPos = transform.position;
    }
    

    void Update()
    {
        float move = Vector3.Distance(transform.position, previousPos);

        if (move >= minmove)
        {
            audioSource.Play();

            previousPos = transform.position;
        }
        
    }
}

