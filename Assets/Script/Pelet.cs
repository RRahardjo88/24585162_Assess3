using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pelet : MonoBehaviour
{
    public int poins = 10;

    protected virtual void Makan() 
    {
        FindObjectOfType<GameManager>().MakanPelet(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacstudent")) {
            Makan();
        }
    }
}
