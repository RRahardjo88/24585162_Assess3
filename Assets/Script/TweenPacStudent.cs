using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPacStudent : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float tweenDuration = 1.0f;
    private WaitForSeconds wait;
    private float targetRotationAngle = 0.0f;
    
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
            // RotateRight(targetPosition);

            targetPosition = startPosition + new Vector3(5.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            // RotateDown(-targetPosition);

            targetPosition = startPosition + new Vector3(0.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            // RotateLeft(targetPosition);

            targetPosition = startPosition;
            yield return MoveToTargetPosition(targetPosition);
            // RotateUp(-targetPosition);
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

}