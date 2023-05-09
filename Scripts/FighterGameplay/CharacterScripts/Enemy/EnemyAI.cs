using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public string previousmoveaction;
    public string previousaction;

    public string moveaction;
    public string action;
    public string jumpaction;
    [SerializeField] public float spacexDistanceMAX;
    [SerializeField] public float spacexDistanceMIN;
    [SerializeField] public float spaceyDistanceMAX;
    [SerializeField] public float spaceyDistanceMIN;
    public float xDistance;
    public bool spacing;
    public bool spacingRemux;
    public float yDistance;
    public bool playerJumped;
    public GameObject player;
    public int playerside;
    public CharacterMovementE character;
    public randomJump rj;
    public randomChance chance;
    public HandleJump jumphandler;
    public Animator playeranim;

    // States

    public bool movingCloser;
    public bool movingFurther;
    public bool agg;
    public bool superagg;
    public bool def;
    public bool pass;
    public bool chil;
    public Wait waiter;
    public bool flag;
    //

    void Start()
    {
        flag = true;
        playerside = -1;
        movingCloser = false;
        movingFurther = false;
        spacing = true;
        spacingRemux = false;
    }

    // Update is called once per frame
    void Update()
    {
        character.move = playerside;
        updatePlayerSide();
        updateDistances();
        checkJump();
        CheckSpacing();
        SetStyle(chance.aggro, chance.superaggro, chance.defensive, chance.passive, chance.chilling);     
        CheckJumped();
        

        if(playerJumped){
            Jump();
        }   
        if(xDistance <10f && yDistance > 16f && yDistance < 17.77f){
            MoveFurther();
        }

        //if(xDistance <10f && yDistance > 16f && yDistance < 17f){
            //MoveFurther();
        //}
        // if spacing == true
        
        if(spacing == true){
            
            if (agg){
            // move toward until set distance
            // when in distance call aggro
                RemuxCheckSpacing(150f,20f,150f,0f);
                if(spacingRemux == true){
                    AGGRO();
                } else {
                    character.moving = 0f;
                }
                
            } else if (superagg){
                // move toward until set distance
                // when in distance call aggro
                RemuxCheckSpacing(150f,19f,150f,0f);
                if(spacingRemux == true){
                    FUCKITWEBALL();
                } else {
                    character.moving = 0f;
                }
            } else if (def){
                resetStates();
                // move away until set distance
                // when in distance, call defense
                RemuxCheckSpacing(100f,40f,100f,0f);
                if(spacingRemux == true){
                    DEFENSE();
                } else {
                    character.moving = 0f;
                }
            } else if (pass){
                resetStates();
                // move away until set distance
                // when in distance, call passive
                RemuxCheckSpacing(130f,60f,130f,0f);
                if(spacingRemux == true){
                    PASSIVE();
                } else {
                    MoveFurther();
                }
            } else if (chil){
                resetStates();
                // do nothing unless player is close
                // if player is close, dash away
                // else chill
                RemuxCheckSpacing(150f,40f,150f,0f);
                if(spacingRemux == true){
                    SHILL();
                } else {
                    MoveFurther();
                }
            }
        }
        

    }

    void updateDistances(){
        xDistance = Mathf.Abs(player.transform.position.x - transform.position.x);
        yDistance = Mathf.Abs(player.transform.position.y - transform.position.y);
    }

    void CheckSpacing(){
        if(xDistance < spacexDistanceMAX && xDistance > spacexDistanceMIN && yDistance < spaceyDistanceMAX && yDistance > spaceyDistanceMIN){
            spacing = true;
            character.moving = 0f;
        } else {
            spacing = false;
        }
    }

    void RemuxCheckSpacing(float xDismax, float xDismin, float yDismax, float yDismin){

        if(xDistance < xDismax && xDistance > xDismin && yDistance < yDismax && yDistance > yDismin){
            spacingRemux = true;
            character.moving = 0f;
        } else {
            spacingRemux = false;
        }
    }

    void SetStyle(bool aggo, bool superaggo, bool deff, bool pas, bool chill){
        if(aggo == true){
            agg = true;
            //Debug.Log("Style is: agg " + xDistance);
        } else if (superaggo == true){
            superagg = true;
            //Debug.Log("Style is: super agg " + xDistance);
        } else if (deff == true){
            def = true;
            //Debug.Log("Style is: def " + xDistance);
        } else if (pas == true){
            pas = true;
            //Debug.Log("Style is: pas " + xDistance);
        } else if (chill == true){
            chil = true;
            //Debug.Log("Style is: chil " + xDistance);
        }
    }

    void setNewAction(string act){
        previousaction = action;
	    action = previousaction + "up";
	    StartCoroutine(Wait());
        action = act;
        StartCoroutine(Wait());
    }

    void setNewMoveAction(string act){
        previousmoveaction = moveaction;
	    moveaction = previousmoveaction + "up";
	    StartCoroutine(Wait());
        moveaction = act;
    }

    void updatePlayerSide(){
        if(player.transform.position.x > transform.position.x){
            playerside = 1;
        }
        if(player.transform.position.x < transform.position.x){
            playerside = -1;
        }
    }

    void Block(){
        Debug.Log("Blocking");
	    setNewAction("Y");
        waiter.timedwait(1f);

    }

    void checkJump(){
        if (rj.jumping == true){
            JumpRandom();
        }
    }

    void Grab(){
        Debug.Log("Grabbing");
        if(playerside == 1){
            setNewMoveAction("D");
            setNewAction("I");
        }
        if(playerside == -1){
            setNewMoveAction("A");
            setNewAction("I");
        }
    }

    void Attack(){
        Debug.Log("Attacking!");
        if(playerside == 1){
            setNewMoveAction("D");
            setNewAction("K");
        }
        if(playerside == -1){
            setNewMoveAction("A");
            setNewAction("H");
        }
    }


    void Jump(){
        jumphandler.Jump();
    }

    void JumpRandom(){
        jumphandler.JumpRandom();
    }

    void JumpScared(){
        jumphandler.ScaredJump();
    }

    /*
    void FastFall(){
        if(agg == true || superagg == true && transform.position.y > -13){
            jumphandler.AggroFastFall();
        }
        //setNewAction("S");
    }
    */
    void CancelFall(){
        moveaction = "Sup";
    }

    void MoveCloser(){
        resetStates();
        movingCloser = true;
        character.away = 1f;
        character.moving = 1f;

        if (playerside == -1){
            setNewMoveAction("A");
        } 

        if (playerside == 1){
            setNewMoveAction("D");
        }
    
    }

    void CheckJumped(){
        updateDistances();
        if (yDistance > 10f){
            playerJumped = true;
        } else {
            playerJumped = false;
        }
    }

    void MoveFurther(){
        resetStates();
        movingFurther = true;
        character.away = -1f;
        character.moving = 1f;
        if (playerside == -1){
            setNewMoveAction("D");
        } 

        if (playerside == 1){
            setNewMoveAction("A");
        }
    }

    void resetStates(){
        movingCloser = false;
        movingFurther = false;
        setNewMoveAction("");
    }

    public void resetStyle(){
        agg = false;
        superagg = false;
        def = false;
        pass = false;
        chil = false;
        spacingRemux = false;
    }

    void Punish(bool grabbed){
        if(!grabbed){
            if(character.adjust == 2f){
                updatePlayerSide();
                updateDistances();
                MoveCloser();
                if(xDistance < 25f){
                    Grab();
                    updatePlayerSide();
                    updateDistances();
                    MoveCloser();
                    Attack();
                } else {
                    StartCoroutine(Wait());
                    Grab();
                    updatePlayerSide();
                    updateDistances();
                    MoveCloser();
                    Attack();
                }
            }
        } else if(grabbed){
            if(character.adjust == 2f){
                updatePlayerSide();
                updateDistances();
                MoveCloser();
                if(xDistance < 25f){
                    Attack();
                    updatePlayerSide();
                    updateDistances();
                    MoveCloser();
                    Attack();
                } else {
                    StartCoroutine(Wait());
                    Grab();
                    updatePlayerSide();
                    updateDistances();
                    MoveCloser();
                    Attack();
                }
            }
        }

    }

    void AGGRO(){
        // if within range attack
        if(xDistance < 30f){
            updatePlayerSide();
            updateDistances();
            
            Attack();
            Punish(false);
            StartCoroutine(MidWait());
            updatePlayerSide();
            updateDistances();
            MoveCloser();
            
            Attack();
            Punish(false);
            StartCoroutine(LongWait());
            updatePlayerSide();
            updateDistances();
            
            MoveCloser();
            Grab();
            Punish(true);
        }
        if(xDistance > 15f){
            
            MoveCloser();
        }
    }

    void DEFENSE(){
	    if(xDistance >70f){
            resetStates();

        } else{
            Block();
            Punish(false);

        }

	
    }

    void SHILL(){
        if (xDistance < 40f){
            MoveFurther();
            JumpScared();
        } else {
            resetStates();
        }
    }

    void PASSIVE(){
        if(xDistance<40f){
            MoveFurther();
        } else {
            resetStates();
        }
        if (playeranim.GetBool("Swipe") == true){
            Grab();
            Punish(true);
        }
    }

    void FUCKITWEBALL(){
        if(xDistance < 30f){
            updatePlayerSide();
            updateDistances();
            Grab();
            //FastFall();
            Punish(true);
            StartCoroutine(MidWait());
            updatePlayerSide();
            updateDistances();
            MoveCloser();
            Grab();
            //FastFall();
            Punish(true);
            StartCoroutine(LongWait());
            updatePlayerSide();
            updateDistances();
            MoveCloser();
            Grab();
            //FastFall();
            Punish(true);
        }
        if(xDistance > 30f){
            MoveCloser();
        }
    }

    IEnumerator Wait(){
        
        yield return new WaitForSeconds(.1f);
    }

    IEnumerator LongWait(){
        
        yield return new WaitForSeconds(.7f);
    }

    IEnumerator MidWait(){
        
        yield return new WaitForSeconds(.6f);
    }

    
    IEnumerator Wait(float time){
        
        yield return new WaitForSeconds(time);
    }
}
