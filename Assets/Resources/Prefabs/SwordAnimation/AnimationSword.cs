using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSword : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var isThisWapon = FindFirstObjectByType<EqScipt>().currentWapon;

        if (isThisWapon == null || isThisWapon.name != gameObject.name) return;

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("SowrdAttack");
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("WalkingWithSword");
        }
    }
}
