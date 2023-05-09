using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriterenderer;

    KeyCode Q = KeyCode.Q;

    private Animator anim;
    private bool waiting;
    private Rigidbody2D rb;  // Rigid body



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(Q) && waiting == false){
            anim.SetBool("Swipe", true);
            waiting = true;
            StartCoroutine(Wait());

        }


    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.05f);
        anim.SetBool("Swipe", false);
        yield return new WaitForSeconds(.4f);
        waiting = false;
    }

}
