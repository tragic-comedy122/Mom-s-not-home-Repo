using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highlightSelectedItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemID;
    public GameObject itemHover;
    private Color alpha;
    private Color parentColor;
    public bool pressed;

    void Start()
    {
        itemID = transform.GetChild(2).gameObject;
        itemHover = transform.GetChild(3).gameObject;
        alpha = itemHover.GetComponent<Image>().color;
        parentColor = transform.GetComponent<Image>().color;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(InventoryManager.Instance.hoveredID);
        if (InventoryManager.Instance.selectedNumber.Equals(itemID.GetComponent<TMP_Text>().GetParsedText()) || itemID.GetComponent<TMP_Text>().GetParsedText().Equals(InventoryManager.Instance.hoveredID)){
            alpha.a = .5f;
            parentColor.a = .5f;
            itemHover.GetComponent<Image>().color = alpha;
        } else{
            parentColor.a = 0f;
            alpha.a = .0f;
            itemHover.GetComponent<Image>().color = alpha;

        }
        
    }
}

