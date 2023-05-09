using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomChance : MonoBehaviour
{
    // Start is called before the first frame update
    public bool waiting;
    public int randomnumber;
    public bool chilling;
    public bool aggro;
    public bool superaggro;
    public bool passive;
    public bool defensive;
    public EnemyAI enemy;
    void Start()
    {
        waiting = false;
        randomnumber = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (!waiting){
            randomnumber = Random.Range(0,4);
            if (randomnumber == 4){
                chilling = true;
                aggro = false;
                superaggro = false;
                passive = false;
                defensive = false;
            } else if (randomnumber == 0){
                chilling = false;
                aggro = true;
                superaggro = false;
                passive = false;
                defensive = false;
            } else if (randomnumber == 1){
                chilling = false;
                aggro = false;
                superaggro = true;
                passive = false;
                defensive = false;
            } else if (randomnumber == 2){
                chilling = false;
                aggro = false;
                superaggro = false;
                passive = true;
                defensive = false;
            } else if (randomnumber == 3){
                chilling = false;
                aggro = false;
                superaggro = false;
                passive = false;
                defensive = true;
            }

            StartCoroutine(Wait());

        }


    }

    IEnumerator Wait(){
        waiting = true;
        yield return new WaitForSeconds(3f);
        enemy.resetStyle();
        waiting = false;
    }
}
