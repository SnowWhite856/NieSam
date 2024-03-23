using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourClass : itemsClass
{
    public ArmourClass(string name, bool stack, int stackLimit, string Description,int armor, int hp):base(name, stack, stackLimit, Description) {
        this.armor = armor;
        this.hp = hp;
    }
    public int armor;
    public int hp;
}
