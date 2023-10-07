using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumahHantu : HantuBehavior
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {

        if (gameObject.activeInHierarchy) {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            hantus.movement.SetDirection(- hantus.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        hantus.movement.SetDirection(Vector2.up, true);
        hantus.movement.rigidbody.isKinematic = true;
        hantus.movement.enabled = false;

        Vector3 position = transform.position;

        float duration = 0.5f;
        float elapsed = 0f;

 
        while (elapsed < duration)
        {
            hantus.SetPosition(Vector3.Lerp(position, inside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < duration)
        {
            hantus.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }
        hantus.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
        hantus.movement.rigidbody.isKinematic = false;
        hantus.movement.enabled = true;
    }

}
