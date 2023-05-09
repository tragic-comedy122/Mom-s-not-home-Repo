using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackleftE : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriterenderer;
    public CharacterMovementE character;
    BoxCollider2D boxCollider;
    //public characterhealth chealth;
    private bool visible;
    private Animator anim;
    private bool waiting;
    private Rigidbody2D rb;  // Rigid body
    public blockE bl;
    public grabE grab;

    public EnemyAI enemyAI;



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

        if (enemyAI.moveaction.Equals("A")){
            if(character.isOnGround){
                visible = true;
            }
        }

        if (enemyAI.moveaction.Equals("D")){
            if(character.isOnGround){
                visible = false;
            }
        }
        if(visible && bl.blocking == false && grab.grabbing == false && character.stunned == false){
            if(enemyAI.action.Equals("H") && waiting == false){
                waiting = true;
                spriterenderer.enabled = true;
                boxCollider.enabled = true;
                anim.SetBool("swipe", true);
                StartCoroutine(Wait());

            }
        }


    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.6f);
        anim.SetBool("swipe", false);
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
