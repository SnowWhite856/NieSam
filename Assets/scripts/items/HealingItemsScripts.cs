using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItemsScripts : itemsClass
{
    public HealingItemsScripts(string name, bool stack, int stackLimit, string Description,float healing,float healingSpeed,float castingTime): base(name, stack, stackLimit, Description)
    {
        this.healing = healing;
        this.healingSpeed = healingSpeed;
        this.castingTime = castingTime;
    }

    public float healing;
    public float healingSpeed;
    public float castingTime;
}
