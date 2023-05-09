using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public characterhealth player;
    public characterhealthE oppose;
    public EnemyAI enemy;
    public CharacterMovement character;
    public TMP_Text gg;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currentHealth < 1 || oppose.currentHealth < 1){
            enemy.enabled = false;
            character.enabled = false;
            gg.enabled = true;
        }
    }
}
