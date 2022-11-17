using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheCrops : ToolHit
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
