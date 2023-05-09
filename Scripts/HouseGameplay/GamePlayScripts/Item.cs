using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    // Start is called before the first frame update
    public string id;
    public string itemName;
    public int value;
    public Sprite icon;
}
