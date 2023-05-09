using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public Item Item;
    private bool flag = false;
    
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
    private void Update() {
        if(Input.GetMouseButtonDown(0) && flag == true)
        {
            Pickup();
        }
    }
    
    void Pickup(){
        InventoryManager.Instance.Add(Item);
        InventoryManager.Instance.loadInventory = true;
        //gameObject.SetActive(false);
    }
}
