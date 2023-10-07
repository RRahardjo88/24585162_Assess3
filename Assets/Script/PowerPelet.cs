using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerPelet : Pelet
{

    public float duration = 8f;

   protected override void Makan()
    {
        FindObjectOfType<GameManager>().MakanPowerPelet(this);
    }
}
