using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPacStudent : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float tweenDuration = 1.0f;
    private WaitForSeconds wait;
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
            transform.LookAt(targetPosition);

            targetPosition = startPosition + new Vector3(5.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            transform.LookAt(targetPosition);

            targetPosition = startPosition + new Vector3(0.0f, -4.0f, 0.0f);
            yield return MoveToTargetPosition(targetPosition);
            transform.LookAt(targetPosition);

            targetPosition = startPosition;
            yield return MoveToTargetPosition(targetPosition);
            transform.LookAt(targetPosition);
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
}