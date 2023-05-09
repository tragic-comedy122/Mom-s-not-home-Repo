using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;
    public int goBack;
    private bool flag = false;
    
    private void Update() {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "DrawerPuzzle" || scene.name == "CabinetPuzzle"|| scene.name == "SafePuzzle")
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(goBack, LoadSceneMode.Single);
            }
        }
        if(Input.GetMouseButtonDown(0) && flag == true)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            flag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            flag = false;
        }
    }
}