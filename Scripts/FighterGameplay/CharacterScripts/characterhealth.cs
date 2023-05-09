using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterhealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth;
    public int currentHealth;
    public updateHealthBar healthbar;
    public CharacterMovement character;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.InitializeHealth(maxHealth);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "attack"){
            removehealth(5);
        }
        if(collision.gameObject.tag == "grab"){
            removehealth(2);
            StartCoroutine(adjustedWaitNegative());
        }

    }


    void removehealth(int damage){
        currentHealth = currentHealth - damage;
        healthbar.updateHealth(currentHealth);
    }

    IEnumerator adjustedWaitNegative(){
        character.adjust = .2f;
        character.stunned = true;
        yield return new WaitForSeconds(.5f);
        character.adjust = 1f;
        character.stunned = false;

    }

}
