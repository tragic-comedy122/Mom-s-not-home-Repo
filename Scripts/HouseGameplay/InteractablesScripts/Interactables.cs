using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour //Assign this script to any object that is to be made interactable and "break" i.e. the vase, plants, etc.
{
    [SerializeField] public GameObject broken; //this is for the broken object
    [SerializeField] public GameObject notBroken;
    [SerializeField] private AudioSource sound; 
                     private bool holder;   
                     public bool knockedDown = false;  
                     public string blah;
                     public NoDestroy noBreaky; 
                     //Make a list that stores all interactables    
    void Update() {
        if(holder)
        {
            if(Input.GetMouseButtonDown(0) && knockedDown == false) //if user clicks left mouse
            {
                brokenStuff();
                noBreaky.brokenInteractables.Add(blah);
                sound.Play();
                GameObject.Find("PopUp").SetActive(false);
                knockedDown = true;
            } 
        }
    }
    
    public void brokenStuff()
    {
        notBroken.SetActive(false); //sets the non-broken object to false
        broken.SetActive(true);   //sets the broken object to active
    }
    private void OnTriggerEnter(Collider other) //Trigger Collision for if the player is near to the interactable
    {
        if(other.gameObject.tag == "Player")
        {
            holder = true;
        }
    }
    private void OnTriggerExit(Collider other) //Trigger Collision for if the player is not near the interactable
    {
        holder = false;    
    }
}
