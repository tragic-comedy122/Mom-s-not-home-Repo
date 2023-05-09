using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 80;
    public float speed = 30f;


    // Update is called once per frame
    public void IncrementHealth()
    {
        health = health + 20;
    }

    public void IncrementSpeed()
    {
        speed = speed + 1f;
    }


    //public Stats stats;

    //stats.IncrementHealth();
    //stats.IncrementSpeed();



}
