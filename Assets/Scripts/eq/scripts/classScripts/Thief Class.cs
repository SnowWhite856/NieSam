using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ThiefClass : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void addStats()
    {
        var player = FindFirstObjectByType<PlayerStats>();
        player.dmg = 4;
        player.ap = 2;
        player.hp = 85;
        player.armor = 20;
        player.movmentSpeed = 7;
    }

    public void specialAbilyty()
    {
        var player = GetComponentInParent<PlayerMovment>();
        Debug.Log("Thief abilyty");
        player.transform.Translate(Vector3.right * 100f * Time.deltaTime);
        anim.SetTrigger("ThiefDash");
    }
}
