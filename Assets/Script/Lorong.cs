using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lorong : MonoBehaviour
{
    public Transform koneksi;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Vector3 position = koneksi.position;
        position.z = other.transform.position.z;
        other.transform.position = position;
    }
}
