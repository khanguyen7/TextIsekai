using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This scriptable object is the template for items
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject {

    public string itemName;
    public int value;
    public string description;

    // public bool stackable
    // public int maxStack;

}
