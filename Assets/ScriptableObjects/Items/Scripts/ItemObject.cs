using UnityEngine;

public enum ItemType {
    Consumable,
    Helmet,
    Chestpiece,
    Leggings,
    Footwear,
    Accessory,
    Weapon,
    Shield,
    Default
}

public enum Attributes {
    attackDMG,
    magicDMG,
    physicalDefense,
    magicDefense,
    agility,
    strength,
    intelligence,
    constitution,
    wisdom,
    wit,
    celerity
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/Item")]
public class ItemObject : ScriptableObject {

    public Sprite itemIcon;
    public bool stackable;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem() {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item {
    public string name;
    public int Id;
    public ItemAttribute[] attributesOnItem;

    public Item() {
        name = "";
        Id = -1;
    }

    public Item(ItemObject item) {
        name = item.name;
        Id = item.data.Id;
        attributesOnItem = new ItemAttribute[item.data.attributesOnItem.Length];
        for (int i = 0; i < attributesOnItem.Length; i++) {
            attributesOnItem[i] = new ItemAttribute(item.data.attributesOnItem[i].min, item.data.attributesOnItem[i].max) {
                attribute = item.data.attributesOnItem[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemAttribute : IModifier {
    public Attributes attribute;
    public int min;
    public int max;
    public int value;
    public ItemAttribute(int _min, int _max) {
        min = _min;
        max = _max;
        GenerateValue();
    }
    public void AddValue(ref int baseValue) {
        baseValue += value;
    }
    public void GenerateValue() {
        value = UnityEngine.Random.Range(min, max);  // Specifying UnityEngine so it doesnt get mad at me
    }
}
