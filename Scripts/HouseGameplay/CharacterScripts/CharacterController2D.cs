using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Cooper
//Hi fren
//is having an issue where you cant jump without the y axis being unlocked in the rigid body
//but with the y axis unlocked the cat floats to like y=0.2 and then falls the floor
//it is possible to jump but it's a bit buggy in that when you are floating the floor check
//fails so cant do jump...
//it could be something easy but im a bit confused and head hurts
//appreciate you friend
//~Matt <3

public class CharacterController2D : MonoBehaviour
{
    public static float speed = 1.5f; //Had to change this to public static for the Stamina bar ~Parker
    
    //Variables for jumpies
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    private Vector3 movingDirection = Vector3.zero;
    public Rigidbody rb;
    public StaminaBar stamina;
    public GameObject popUp;
    bool canJump;
    private bool flag;
    public Animator animator;
    public VectorValue startingPosition;


    private void Awake() {
        transform.position = startingPosition.initalValue;
    }
    private void OnCollisionEnter(Collision other) { 
        if(other.gameObject.tag == "Floor") {
            canJump = true;
            //Debug.Log("notpeen");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bed")
        {
            flag = true;
        }
        if(other.gameObject.tag == "Interact" || other.gameObject.tag == "Item" && other.gameObject.activeInHierarchy)
        {
            popUp.SetActive(true);
        }
        
    }

    public void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Bed")
        {
            flag = false;
        }
        if(other.gameObject.tag == "Interact" || other.gameObject.tag == "Item")
        {
            popUp.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update() {
        Movement();
        if(flag == false)
        {
            StopCoroutine(stamina.Gain());
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q) && flag == true)
        {
            Debug.Log("WE HIT Q OH MY GAWDDD");
            StopCoroutine(stamina.Drain());
            StartCoroutine(stamina.Gain());
        }
    }
    void Movement()
    {
        if(stamina.canMove)
        {    
            //wasd movement
            if (Input.GetKey(KeyCode.D)){
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                animator.SetBool("Press D", true);
            }
            else
            {
                animator.SetBool("Press D", false);
            }
            if (Input.GetKey(KeyCode.A)){
                transform.Translate((Vector3.right) * -1 * Time.deltaTime * speed);
                animator.SetBool("Press A", true);
            }
            else
            {
                animator.SetBool("Press A", false);
            }
            if (Input.GetKey(KeyCode.W)){
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                animator.SetBool("Press W", true);
            }
            else
            {
                animator.SetBool("Press W", false);
            }
            if (Input.GetKey(KeyCode.S)){
                transform.Translate((Vector3.forward)* -1 * Time.deltaTime * speed);
                animator.SetBool("Press S", true);
            }
            else
            {
                animator.SetBool("Press S", false);
            }
            //Jumpies
            if (Input.GetKey(KeyCode.Space) & canJump) {
                transform.Translate(Vector3.up * jumpSpeed /gravity);
                //Debug.Log("pEEN");
                canJump = false;
            }
        }
        else
        {
            speed = .15f;
        }
    }
}
