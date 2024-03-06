using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    void Awake()
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
            anim.SetTrigger("BaseAttack");
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("WalkingWithSpear");
        }
    }
}
