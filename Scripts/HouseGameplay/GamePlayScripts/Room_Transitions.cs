using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Room_Transitions : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;
    public int currentScene;
    //public Scene[] saved_scenes;
    public Vector3 playerPosition;
    public VectorValue playerStorage;
    public static InventoryManager InventoryManager;
    //public Item key;
    
    private void OnTriggerEnter(Collider other) //Note: Need to add key mechanics with items
    //Trigger
    {
        string path = Application.persistentDataPath;
        //old code
        // if(other.tag == "Player" && InventoryManager.Instance.gimmieKey() == true)
        // {
        //     //playerStorage.initalValue = playerPosition;
            
        //     SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
        // }
        // if(other.tag == "Player" && InventoryManager.Instance.Items.Contains(key)) 
        // {
        //     playerStorage.initalValue = playerPosition;
            
        //     SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
        // }
        //Trigger saves current scene to a File
        //DataPersistenceManager.instance.SaveGame();
        
        // if(File.Exists(path + "game.json") && other.tag == "Player" && InventoryManager.Instance.Items.Contains(key))
        // {
        //     SceneManager.LoadSceneAsync(sceneBuildIndex);
        // }
        if(other.tag == "Player") //&& InventoryManager.Instance.Items.Contains(key))
        {
            SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
            playerStorage.initalValue = playerPosition;
            GameObject.Find("GORB").transform.position = playerPosition;
        }
    }
    
}


