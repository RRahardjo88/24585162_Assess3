using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hantu))]
public class HantuBehavior : MonoBehaviour
{
 
    public Hantu hantus { get; private set; }
    public float duration;

    private void Awake()
    {
        hantus = GetComponent<Hantu>();
    }

    public void Enable()
    {
        Enable(duration);

    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }

}
