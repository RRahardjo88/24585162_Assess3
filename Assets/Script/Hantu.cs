using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(Movement))]
public class Hantu : MonoBehaviour
{
    public Movement movement { get; private set; }
    public RumahHantu rumah { get; private set; }
    public HantuScatter scatter { get; private set; }
    public HantuChase chase { get; private set; }
    public HantuFrightened frightened { get; private set; }
    public HantuBehavior initialBehavior;
    public Transform target;
    public int poins = 200;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        rumah = GetComponent<RumahHantu>();
        scatter = GetComponent<HantuScatter>();
        chase = GetComponent<HantuChase>();
        frightened = GetComponent<HantuFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (rumah != initialBehavior) {
            rumah.Disable();
        }

        if (initialBehavior != null) {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacstudent"))
        {
            if (frightened.enabled) {
                FindObjectOfType<GameManager>().MakanHantu(this);
            } else {
                FindObjectOfType<GameManager>().PacStudentMakan();
            }
        }
    }
}
