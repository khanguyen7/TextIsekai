using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour {

    public InventoryObject inventory;
    public GameObject slotPrefab;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            var obj = Instantiate(inventory.Container[i].item.itemPrefab, transform);
            obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            if (itemsDisplayed.ContainsKey(inventory.Container[i])) {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            }
            else {
                var obj = Instantiate(inventory.Container[i].item.itemPrefab, transform);
                obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
