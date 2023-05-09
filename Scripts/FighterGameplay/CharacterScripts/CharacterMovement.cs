using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriterenderer;
    KeyCode A = KeyCode.A;
    KeyCode D = KeyCode.D;
    KeyCode S = KeyCode.S;
    KeyCode Spacebar = KeyCode.Space;
    private Animator anim;

    [SerializeField] private float speed; // Speed
    [SerializeField] private float Jump; // Jump
    public float move;
    public bool isOnGround;
    public float gravityscale;
    public float groundSpeed;
    public float downSpeed;
    private Rigidbody2D rb;  // Rigid body
    public string facing;
    public bool stunned;
    public float adjust;
    //private float dashpower = 24f;
    //private float dashTime = .2f;
    //private float dashCoolDown = 1f;



    void Start()
    {
        adjust = 1;
        Jump = Jump * 10;
        Physics2D.gravity = new Vector2(0, -gravityscale);
        anim = gameObject.GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        isOnGround = true;
        rb = GetComponent<Rigidbody2D>(); // On first instance, assign rb to the rigidbody of the object
        facing = "none";
        stunned = false;

    }


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor"){
            isOnGround = true;
            anim.SetBool("walking", false);
        }
        if(collision.gameObject.tag == "grab"){
            StartCoroutine(grabbed());
        }

        
    }
 
    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxisRaw("Horizontal"); // Get the horizontal axis
        if(isOnGround){
           rb.velocity = new Vector2(groundSpeed * move * adjust, rb.velocity.y);  
        } else if(!isOnGround) {
           rb.velocity = new Vector2(speed * move * adjust, rb.velocity.y);
        }



        if (Input.GetKey(A)){
            facing = "left";
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                spriterenderer.flipX = true;
                anim.SetBool("walking", true);
            }

        }
        if (Input.GetKeyUp(A)){
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                anim.SetBool("walking", false);
            }
            
        }

        if (Input.GetKey(D)){
            facing = "right";
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                spriterenderer.flipX = false;
                anim.SetBool("walking", true);
            }

        }

        if (Input.GetKeyUp(D)){
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                anim.SetBool("walking", false);
            }
        }


        if (Input.GetKey(S)){
            Physics2D.gravity = new Vector2(0, -gravityscale*downSpeed);
        }

        if (Input.GetKeyUp(S)){
            Physics2D.gravity = new Vector2(0, -gravityscale);
        }

        

        if(Input.GetKey(Spacebar) && isOnGround){
            rb.AddForce(new Vector2(rb.velocity.x, Jump));
            isOnGround = false;
        }      

    }

    private IEnumerator grabbed(){
        stunned = true;
        adjust = .3f;
        yield return new WaitForSeconds(.5f);
        stunned = false;
        adjust = 1f;
    }


}
