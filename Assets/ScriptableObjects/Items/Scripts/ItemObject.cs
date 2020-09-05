using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {

    Consumable,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject {

    public GameObject itemPrefab;
    public ItemType type;

    [TextArea(15, 20)]
    public string description;
}
