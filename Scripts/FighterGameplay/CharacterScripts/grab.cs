using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D boxCollider;
    //public SpriteRenderer spriterenderer;
    public bool grabbing;
    KeyCode I = KeyCode.I;
    public CharacterMovement character;
    public Animator anim;

    private float dashpower = 3f;
    private float dashTime = .3f;
    private float dashCoolDown = 1f;
    [SerializeField] private Rigidbody2D rb;
    public block block;

    void Start()
    {
        grabbing = false;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "block"){
            StartCoroutine(adjustedWaitPositive());
        }
        if(collision.gameObject.tag == "attack"){
            StartCoroutine(adjustedWaitNegative());
        }

        if(collision.gameObject.tag == "Player"){
            StartCoroutine(adjustedWaitPositive());
        }
    }


    void Update()
    {
        if (character.isOnGround){
            dashpower = 2f;
        } else {
            dashpower = 3f;
        }

        if (Input.GetKeyDown(I) && !grabbing){
            //transform.enabled = true;
            if(anim.GetBool("Swipe") == false && block.blocking == false && character.stunned == false){
                boxCollider.enabled = true;
                StartCoroutine(Dash());
                StartCoroutine(Cooldown());
            }
            
        }
    }


    private IEnumerator Dash(){
        grabbing = true;
        character.adjust = dashpower;
        yield return new WaitForSeconds(dashTime);
        character.adjust = 1f;
        //spriterenderer.enabled = false;
        boxCollider.enabled = false;
    }

    private IEnumerator Cooldown(){
        yield return new WaitForSeconds(dashCoolDown);
        grabbing = false;
        
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
