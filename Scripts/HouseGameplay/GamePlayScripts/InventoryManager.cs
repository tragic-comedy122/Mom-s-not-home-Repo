using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public bool loadInventory;
    public int currentCount;
    KeyCode One = KeyCode.Alpha1;
    KeyCode Two = KeyCode.Alpha2;
    KeyCode Three = KeyCode.Alpha3;
    KeyCode Four = KeyCode.Alpha4;
    KeyCode Five = KeyCode.Alpha5;
    KeyCode Six = KeyCode.Alpha6;
    KeyCode Seven  = KeyCode.Alpha7;
    KeyCode Eight = KeyCode.Alpha8;
    KeyCode Nine = KeyCode.Alpha9;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Item selectedItem;
    public string selectedNumber;
    public int count;
    public Item emptyItem;
    public string hoveredID;
    public bool clicked;
    public bool pressed;
    private bool hasBathKey;
    private bool hasBedKey;
    private bool hasBackKey;
    public Stats stats; 
    //public Item bathroomKey;
    // public Item bathroomKey;
    // public Item bathroomKey;
    private void Awake(){
        loadInventory = false;
        selectedNumber = "0";
        hoveredID = "0";
        // if(GameObject.Find("Inventory Manager") != null)
        // {
        //     Destroy(this.gameObject);
        // }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }
    // public bool bathroom()
    // {
    //     if(Items.Contains(bathroomKey))
    //     {
    //         return hasKey = true;
    //     }
    //     else
    //     return hasKey = false;
    // }
    // public bool bedroom()
    // {
    //     if(Items.Contains(bedroomKey))
    //     {
    //         return hasKey = true;
    //     }
    //     else
    //     return hasKey = false;
    // }
    // public bool backyard()
    // {
    //     if(Items.Contains(backyardKey))
    //     {
    //         return hasKey = true;
    //     }
    //     else
    //     return hasKey = false;
    // }
    private void Update(){
        if(loadInventory){
            ListItems();
            loadInventory = false;
        }
        


        if (Input.GetKeyDown(One)){
            clicked = true; 
          
            if(selectedNumber.Equals("1")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "1";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
            
        }

        if (Input.GetKeyDown(Two)){ 
            clicked = true;
            
            if(selectedNumber.Equals("2")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "2";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }

        if (Input.GetKeyDown(Three)){ 
            clicked = true;
            
            if(selectedNumber.Equals("3")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "3";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }

        if (Input.GetKeyDown(Four)){ 
            clicked = true;
         
            if(selectedNumber.Equals("4")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "4";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        } 

        if (Input.GetKeyDown(Five)){
            clicked = true;
        
            if(selectedNumber.Equals("5")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "5";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        } 

        if (Input.GetKeyDown(Six)){ 
            clicked = true;
           
            if(selectedNumber.Equals("6")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "6";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }

        if (Input.GetKeyDown(Seven)){ 
            clicked = true;
            
            if(selectedNumber.Equals("7")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "7";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }

        if (Input.GetKeyDown(Eight)){ 
            clicked = true;
            
            if(selectedNumber.Equals("8")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                clicked = false;
                pressed = false;
            } else {
                selectedNumber = "8";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }

        if (Input.GetKeyDown(Nine)){ 
            clicked = true;
            if(selectedNumber.Equals("9")){
                selectedNumber = "0";
                selectedItem = emptyItem;
                pressed = false;
            } else {
                selectedNumber = "9";
                selectedItem = Items[int.Parse(selectedNumber)-1];
                pressed = true;
            }
        }        


    }

    public void Add(Item item){
        if ((currentCount < 9)){
            Items.Add(item);
            currentCount++;
        }
    }

    public void Remove(Item item){
        Items.Remove(item);
        currentCount+=-1;
    }

    public void ListItems(){
        count = 0;
        foreach (Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        foreach(var item in Items){
                count++;
                
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                var itemId = obj.transform.Find("ItemId").GetComponent<TMP_Text>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemId.text = count.ToString();

        }
    }

    public void adjustPlayerStats(){
        foreach(var item in Items){
            if (item.itemName.Equals("Food")){
                stats.IncrementHealth();
            }
            if (item.itemName.Equals("Worms")){
                stats.IncrementSpeed();
            }
        }
    }
}
