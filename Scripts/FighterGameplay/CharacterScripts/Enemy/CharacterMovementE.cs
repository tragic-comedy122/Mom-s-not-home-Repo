using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementE : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriterenderer;
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
    public EnemyAI enemyAI;
    public float moving;
    public float away;
    //private float dashpower = 24f;
    //private float dashTime = .2f;
    //private float dashCoolDown = 1f;



    void Start()
    {
        away = 1f;
        moving = 0f;
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
        //move = Input.GetAxisRaw("Horizontal");
        // WE WANT A LEFT AND RIGHT HERE

        if(isOnGround){
           rb.velocity = new Vector2(groundSpeed * move * adjust * moving * away, rb.velocity.y);  
        } else if(!isOnGround) {
           rb.velocity = new Vector2(speed * move * adjust * moving * away, rb.velocity.y);
        }



        if (enemyAI.moveaction.Equals("A")){
            facing = "left";
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                spriterenderer.flipX = true;
                anim.SetBool("walking", true);
            }

        }
        if (enemyAI.moveaction.Equals("Aup")){
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                anim.SetBool("walking", false);
            }
            
        }

        if (enemyAI.moveaction.Equals("D")){
            facing = "right";
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                spriterenderer.flipX = false;
                anim.SetBool("walking", true);
            }

        }

        if (enemyAI.moveaction.Equals("Dup")){
            if (!isOnGround){
                anim.SetBool("walking", false);
            }
            if (isOnGround){
                anim.SetBool("walking", false);
            }
        }


        if (enemyAI.moveaction.Equals("S")){
            Physics2D.gravity = new Vector2(0, -gravityscale*downSpeed);
        }

        if (enemyAI.moveaction.Equals("Sup")){
            Physics2D.gravity = new Vector2(0, -gravityscale);
        }

        

        if(enemyAI.jumpaction.Equals("Space") && isOnGround){
            rb.AddForce(new Vector2(rb.velocity.x * 1f, Jump * 1f));
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
