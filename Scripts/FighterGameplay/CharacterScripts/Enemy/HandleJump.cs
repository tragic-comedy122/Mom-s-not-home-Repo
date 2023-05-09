using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleJump : MonoBehaviour
{

    public EnemyAI ai;
    public randomJump rj;
    public float yDistance;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpRandom(){
        ai.jumpaction = "Space";
        StartCoroutine(WaitRandom());
    }

    public void Jump(){
        ai.jumpaction = "Space";
        yDistance = Mathf.Abs(player.transform.position.y - transform.position.y);
        StartCoroutine(Wait(1f));

    }

    public void ScaredJump(){
        if(ai.xDistance < 10f){
            ai.jumpaction =  "Space";
            StartCoroutine(WaitConstant());
        }
    }

    public void FastFall(){
        ai.jumpaction = "S";
    }

    public void AggroFastFall(){
        while(ai.transform.position.y > -12){
            if(ai.transform.position.y > ai.player.transform.position.y){
                while(ai.transform.position.y>ai.player.transform.position.y){
                    ai.jumpaction = "S";
                }
                ai.jumpaction = "Sup";
            }
        }

    }

    IEnumerator WaitConstant(){
        
        yield return new WaitForSeconds(.8f);
        ai.jumpaction = "";
    }

    IEnumerator WaitRandom(){
        
        yield return new WaitForSeconds(rj.jumptime);
        ai.jumpaction = "";
    }

    IEnumerator Wait(float time){
        
        yield return new WaitForSeconds(time);
        ai.jumpaction = "";
    }
}
