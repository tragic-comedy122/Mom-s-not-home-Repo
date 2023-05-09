using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
    public bool blocking;
    KeyCode Y = KeyCode.Y;

    private Collider2D coll;
    private SpriteRenderer rend;
    public Animator anim;
    public grab grab;
    private float growFactor;
    private Vector3 holdervector;
    private Vector3 startSize;

    public CharacterMovement character;

    void Start()
    {
        startSize = transform.localScale;
        //Debug.Log(startSize.x);
        holdervector = new Vector3(1f,0.1f,0.1f);
        growFactor = -1f;
        blocking = false;
        coll = transform.gameObject.GetComponent<Collider2D>();
        rend = transform.gameObject.GetComponent<SpriteRenderer>();
        coll.enabled = false;
        rend.enabled = false;

    }


    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "grab"){
            StartCoroutine(adjustedWaitNegative());
        }
        if(collision.gameObject.tag == "attack"){
            StartCoroutine(adjustedWaitPositive());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Y)){
            //transform.enabled = true;
            if(anim.GetBool("Swipe") == false && grab.grabbing == false){
                character.adjust = .2f;
                blocking = true;
                coll.enabled = true;
                rend.enabled = true;
                if(transform.localScale.x > holdervector.x){
                    transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                }
                

            }

            
        }

        if (!Input.GetKey(Y)){
            if(transform.localScale.x < startSize.x){
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * (growFactor*-.5f);
            }
        }




        if (Input.GetKeyUp(Y)){
            //transform.enabled = false;
            blocking = false;
            character.adjust = 1;
            coll.enabled = false;
            rend.enabled = false;
        }
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
