using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestroy : MonoBehaviour
{   
    //Start is called before the first frame update
    public List<string> brokenInteractables = new List<string>();
    public List<GameObject> interactablesList = new List<GameObject>();
    public GameObject[] player;
    
    void Start()
    {
        
        // //TODO: HAVE A CHECK FOR WHEN YOU TRANSFER SCENES
        // //TODO: NAME ALL INTERACTBLE OBJ
        // //GIVE REFERENCE TO NODESTROY

        
        player = GameObject.FindGameObjectsWithTag("Player");
        if(player.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Item"))
        {
            interactablesList.Add(obj);
        }
        foreach(GameObject interactable in interactablesList) 
        {   
            Debug.Log(brokenInteractables.Count);
            if(brokenInteractables.Count > 1 )
            {
                Debug.Log(brokenInteractables[0]);
            }
            if (brokenInteractables.Contains(interactable.GetComponent<Interactables>().blah))
            {
                Debug.Log("This is run");
                interactable.GetComponent<Interactables>().brokenStuff();
            }
        }
    }
    private void Update() 
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "DrawerPuzzle" || scene.name == "CabinetPuzzle"|| scene.name == "SafePuzzle")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
