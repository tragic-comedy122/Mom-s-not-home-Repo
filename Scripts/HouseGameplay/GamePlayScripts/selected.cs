using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class selected : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private Color alpha;
    public GameObject aparent;
    public string itemID;
    public Item emptyItem;
    void Start(){
        alpha = transform.GetComponent<Image>().color;
        aparent = transform.parent.gameObject;
        StartCoroutine(Wait());
    }

    // Update is called once per frame


    public void OnPointerEnter(PointerEventData eventData){
        InventoryManager.Instance.hoveredID = itemID;
        alpha.a = .5f;
        transform.GetComponent<Image>().color = alpha;
    }

    public void OnPointerExit(PointerEventData eventData){
        InventoryManager.Instance.hoveredID = "0";
        if(aparent.GetComponent<Image>().color.a != .5f){
            alpha.a = 0f;
            transform.GetComponent<Image>().color = alpha;
        }

    }

    public void OnPointerClick(PointerEventData eventData){
        if(InventoryManager.Instance.pressed){
            InventoryManager.Instance.pressed = false;
            InventoryManager.Instance.selectedNumber = "0";
            InventoryManager.Instance.selectedItem = emptyItem;
            InventoryManager.Instance.clicked = false;    
        } else if (!InventoryManager.Instance.pressed){
            InventoryManager.Instance.pressed = true;
            InventoryManager.Instance.selectedNumber = itemID;
            InventoryManager.Instance.selectedItem = InventoryManager.Instance.Items[int.Parse(itemID)-1];
        }
        
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.05f);
        itemID = transform.parent.GetChild(2).gameObject.GetComponent<TMP_Text>().GetParsedText();
    }
}
