using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomJump : MonoBehaviour
{
    public EnemyAI enemy;
    public float jumptime;
    public float jumpnumber;
    public bool jumping;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        jumpnumber = Random.Range(0,4);
        if(jumpnumber == 4){
            jumptime = Random.Range(0f,1f);
        }


    }

    IEnumerator Wait(){
        jumping = true;
        yield return new WaitForSeconds(2f);
        //enemy.resetStyle();
        jumping = false;
    }
}


