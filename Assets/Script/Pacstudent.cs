using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacstudent : MonoBehaviour
{

    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public Movement movement {get; private set;}
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float tweenDuration = 1.0f;
    private WaitForSeconds wait;
    private float targetRotationAngle = 0.0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        movement = GetComponent<Movement>();
    }
    void Start()
    {
        startPosition = transform.position;
        wait = new WaitForSeconds(tweenDuration);

        StartCoroutine(PerformMovements());

        }
    
    IEnumerator PerformMovements()
    {
        while (true) 
        {
            targetPosition = startPosition + new Vector3(5.0f, 0.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            RotateRight(targetPosition);

            targetPosition = startPosition + new Vector3(5.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            RotateDown(-targetPosition);

            targetPosition = startPosition + new Vector3(0.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            RotateLeft(targetPosition);

            targetPosition = startPosition;
            yield return MoveToTargetPosition(targetPosition);
            RotateUp(-targetPosition);
        }
    }

    IEnumerator MoveToTargetPosition(Vector3 target)
    {
        float elapsedTime = 0.0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < tweenDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, target, elapsedTime / tweenDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target; 

    }
    void RotateDown(Vector3 targetPosition)
{
    float targetAngle = 180.0f;

    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
}
    void RotateUp(Vector3 targetPosition)
{
    float targetAngle = 0.0f;

    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
}
    void RotateRight(Vector3 targetPosition)
{
    float targetAngle = 90.0f;

    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
}
    void RotateLeft(Vector3 targetPosition)
{
    float targetAngle = 270.0f;

    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
}

    // private void Update () 
    // {
    //     if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) 
    //     {
    //         this.movement.SetDirection(Vector2.up);
    //     } 
    //     else if(Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)) 
    //     {
    //         this.movement.SetDirection(Vector2.down);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow)) 
    //     {
    //         this.movement.SetDirection(Vector2.left);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)) 
    //     {
    //         this.movement.SetDirection(Vector2.right);
    //     }
    //     float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
    //     this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
       
    // }

    public void ResetState()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        collider.enabled = true;
        movement.ResetState();
        gameObject.SetActive(true);
    } 
}
