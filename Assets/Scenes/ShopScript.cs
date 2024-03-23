using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    Animator anim;

    private void OnMouseDown()
    {
        GameObject camera = GameObject.Find("Main Camera");
        anim = camera.GetComponent<Animator>();
        StartCoroutine(rotateCamera());
        goToShop(camera);
        FindFirstObjectByType<dialougeScript>().shopOn();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.SetTrigger("BackToStart");
            backSlow();
        }
    }

    void backSlow()
    {
        GameObject camera = GameObject.Find("Main Camera");
        Vector3 target = new Vector3(1007.08f, 444.41f, 0.39f);
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, target, 80f * Time.deltaTime);
        if (camera.transform.position != target)
        {
            StartCoroutine(back());
        }
    }

    IEnumerator back()
    {
        yield return new WaitForSeconds(0.01f);
        backSlow();
    }

    IEnumerator rotateCamera()
    {
        yield return new WaitForSeconds(0.08f);
        anim.SetTrigger("GoStoShop");
    }

    public void goToShop(GameObject camera)
    {
        Vector3 target = new Vector3(1020, 444, 7);
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, target, 80f * Time.deltaTime);
        if (camera.transform.position != target)
        {
            StartCoroutine(goSlowly(camera));
        }
    }

    IEnumerator goSlowly(GameObject camera)
    {
        yield return new WaitForSeconds(0.01f);
        goToShop(camera);
    }
}
