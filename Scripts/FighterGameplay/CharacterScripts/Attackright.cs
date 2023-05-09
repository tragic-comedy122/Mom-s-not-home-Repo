using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackright : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriterenderer;
    public CharacterMovement character;
    BoxCollider2D boxCollider;
    KeyCode K = KeyCode.K;
    KeyCode A = KeyCode.A;
    KeyCode D = KeyCode.D;
    private bool visible;
    private Animator anim;
    private bool waiting;
    private Rigidbody2D rb;  // Rigid body
    public block bl;
    public grab grab;

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "block"){
            StartCoroutine(adjustedWaitNegative());
        }

        if(collision.gameObject.tag == "grab"){
            StartCoroutine(adjustedWaitPositive());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(A)){
            if(character.isOnGround){
                visible = false;
            }
        
        }

        if (Input.GetKey(D)){
            if(character.isOnGround){
                visible = true;
            }

        }

        if(visible && bl.blocking == false && grab.grabbing == false && character.stunned == false){
            if(Input.GetKey(K) && waiting == false){
                spriterenderer.enabled = true;
                boxCollider.enabled = true;
                anim.SetBool("Swipe", true);
                waiting = true;
                StartCoroutine(Wait());

            }
        }


    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.18f);
        anim.SetBool("Swipe", false);
        spriterenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(.4f);
        waiting = false;
    }


    IEnumerator adjustedWaitPositive(){
        character.adjust = 2f;
        yield return new WaitForSeconds(.5f);
        character.adjust = 1f;
    }

    IEnumerator adjustedWaitNegative(){
        character.adjust = .2f;
        character.stunned = true;
        yield return new WaitForSeconds(.5f);
        character.adjust = 1f;
        character.stunned = false;

    }
}
