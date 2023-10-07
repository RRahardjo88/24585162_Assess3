using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HantuFrightened : HantuBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;

    public bool makan { get; private set; }

    public override void Enable(float duration)
    {

        base.Enable(duration);

        body.enabled = false;
        eyes.enabled = false;
        blue.enabled = true;
        white.enabled = false;

        Invoke(nameof(Flash), duration / 2f);

    
    }

    public override void Disable()
    {

        base.Disable();

        body.enabled = true;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;
    }

    private void Makan()
    {
        makan = true;
        hantus.SetPosition(hantus.rumah.inside.position);
        hantus.rumah.Enable(duration);

        body.enabled = false;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;

        
    }

    private void Flash()
    {
        if (!makan)
        {
            blue.enabled = false;
            white.enabled = true;
            white.GetComponent<AnimasiSprite>().Restart();
        }
    }

    private void OnEnable()
    {
        blue.GetComponent<AnimasiSprite>().Restart();
        hantus.movement.speedMultiplier = 0.5f;
        makan = false;
    }

    private void OnDisable()
    {
        hantus.movement.speedMultiplier = 1f;
        makan = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {

                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (hantus.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            hantus.movement.SetDirection(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacstudent"))
        {
            if (enabled) {
                Makan();
            }
        }
    }

}

