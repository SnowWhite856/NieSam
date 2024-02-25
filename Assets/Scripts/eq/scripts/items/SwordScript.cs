using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<WaponsClass>().atackSpeed = 1;
        int rn = Random.Range(1,100);
        if(rn < 50)
        {
            GetComponent<WaponsClass>().attackDmg = 10;
            GetComponent<WaponsClass>().rarity = "common";
        }else if(rn>50 && rn < 75)
        {
            GetComponent<WaponsClass>().attackDmg = 15;
            GetComponent<WaponsClass>().rarity = "uncommon";
        }
        else if(rn>75 && rn < 90)
        {
            GetComponent<WaponsClass>().attackDmg = 20;
            GetComponent<WaponsClass>().rarity = "rare";
        }
        else if(rn>90 && rn < 100)
        {
            GetComponent<WaponsClass>().attackDmg = 25;
            GetComponent<WaponsClass>().rarity = "epic";
        }
        else
        {
            GetComponent<WaponsClass>().attackDmg = 55;
            GetComponent<WaponsClass>().rarity = "legendary";
        }
    }
}
