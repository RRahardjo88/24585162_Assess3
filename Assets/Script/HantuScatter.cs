using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HantuScatter : HantuBehavior
{
    private void OnDisable()
    {
        hantus.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();


        if (node != null && enabled && !hantus.frightened.enabled)
        {
 
            int index = Random.Range(0, node.availableDirections.Count);



            if (node.availableDirections.Count > 1 && node.availableDirections[index] == -hantus.movement.direction)
            {
                index++;

   
                if (index >= node.availableDirections.Count) {
                    index = 0;
                }
            }

            hantus.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
