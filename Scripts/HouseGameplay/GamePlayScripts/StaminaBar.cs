using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Slider staminaBar;
    private float maxStamina = 100;
    private float currentStamina;
    private float orginalSpeed = CharacterController2D.speed;
    public bool canMove;
    
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;

        StartCoroutine(Drain());
    }
    void Update() { //THIS METHOD IS FOR TESTING PURPOSES AND ONCE FULLY IMPLEMENTED CAN BE DELETED
        if(Input.GetKey(KeyCode.P)) 
        {
            currentStamina = 100;
        }
    }
    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            CharacterController2D.speed = orginalSpeed;
        }
        else
        {
            CharacterController2D.speed = 1;
        }
    }
    public IEnumerator Drain()
    {
        while(currentStamina >= 0)
        {
            UseStamina(0.5f);
            yield return new WaitForSeconds(1.0f);
        }
    }
    public IEnumerator Gain()
    {
        while(currentStamina <= 100)
        {
            canMove = false;
            currentStamina += 5;
            yield return new WaitForSeconds(1.0f);
        }
        canMove = true;
    }
}
