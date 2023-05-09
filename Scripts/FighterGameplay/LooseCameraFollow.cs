using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script does two things, Sets the camera inbetween the fighters
// and expands it when they get too far apart

// It takes the positions of both fighters, and calculates the center and 
// distance in between them

// With this information, the camera is adjusted

// Keep in mind the value 112 is just the distance apart needed for the camera can expand








public class LooseCameraFollow : MonoBehaviour
{
    
    // Positions of both fighters
    public Vector3 PlayerPos;
    public Vector3 EnemyPos;
    public Vector3 center;
    public float distanceBetween;
    public bool expanding;
    public float fov;

    // These are reccomended values
    private float startfov;
    private float distanceBeforeCameraExpansion;
    public float cameraYoffset;
    private float cameraExpansionRatio;


    void Start() // Assign start values
    {
        cameraExpansionRatio = 8;
        distanceBeforeCameraExpansion = 135;
        startfov = 19.3f; // This is what I found worked best hence private
        fov = startfov; // set our current fov to startfov
        expanding = false; // Not expanding on start
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(distanceBetween);
        // Every frame get their locations
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        EnemyPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
        // Calculate distance between players
        distanceBetween = Vector3.Distance(PlayerPos, EnemyPos);
        
        //Mathf.Abs(Mathf.Abs(PlayerPos.x) + Mathf.Abs(EnemyPos.x));

        // Set the cameras position to inbetween
        center = ((PlayerPos + EnemyPos)*0.5f);
        center.y = cameraYoffset; // Adjust camera offset
        transform.position = center;

        // Check if camera needs expansion
        if (distanceBetween > distanceBeforeCameraExpansion){
            expanding = true;
        } 
        if (distanceBetween < distanceBeforeCameraExpansion){
            expanding = false;
        }
        // If camera needs to expand, change the position to a calculated value
        if (expanding == true){
            fov = startfov + (distanceBetween/distanceBeforeCameraExpansion)*cameraExpansionRatio;
            Camera.main.fieldOfView = fov;
        }


    }
}
