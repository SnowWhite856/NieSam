using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeffence : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
    anim = GetComponent<Animator>();
    }

// Update is called once per frame
void Update()
    {
        var isThisWapon = FindFirstObjectByType<EqScipt>().currentWapon2;

        if (isThisWapon == null || isThisWapon.name != gameObject.name) return;

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("ShieldOn");
        }

        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetTrigger("ShieldOff");
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("WalkingWithShield");
        }
    }
}
