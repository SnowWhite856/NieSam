using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaponsClass : itemsClass
{
    public WaponsClass(string name, bool stack, int stackLimit, string Description,int attackDmg, int ablilityDmg, float atackSpeed, int manaCost, string rarity):base(name, stack, stackLimit, Description) {
        this.name = name;
        this.stack = stack;
        this.stackLimit = stackLimit;
        this.Description = Description;
        this.attackDmg = attackDmg;
        this.ablilityDmg = ablilityDmg;
        this.atackSpeed = atackSpeed;
        this.manaCost = manaCost;
        this.rarity = rarity;
    }

    public int attackDmg;
    public int ablilityDmg;
    public float atackSpeed;
    public int manaCost;
    public string rarity;

}
