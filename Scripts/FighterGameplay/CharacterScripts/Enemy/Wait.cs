using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update

    public EnemyAI ai;

    public void timedwait(float wait){
        StartCoroutine(Waits(wait));
    }


    // Update is called once per frame
    IEnumerator Waits(float time){
        
        yield return new WaitForSeconds(time);
        ai.action = "Yup";
        yield return new WaitForSeconds(.1f);
        ai.action = "";
    }
}
