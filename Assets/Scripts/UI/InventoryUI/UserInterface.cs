using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// The UserInterface class allows for interaction with an Inventory UI. E.g. dragging items around, swapping items.
public abstract class UserInterface : MonoBehaviour {
    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>(); // A dictionary that contains the inventory's slots as values, and the slots' prefab object as keys.
    // Awake is called once 
    void Awake() {
        for (int i = 0; i < inventory.GetSlots.Length; i++) {
            inventory.GetSlots[i].SetParent(this);
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    private void OnSlotUpdate(InventorySlot _slot) {
        var slotImage = _slot.slotDisplay.transform.GetChild(0).GetComponent<Image>();

        if (_slot.item.Id >= 0) {
            slotImage.sprite = _slot.ItemObject.itemIcon;
            slotImage.color = new Color(1, 1, 1, 1);
            _slot.slotDisplay.GetComponentInChildren<Text>().text = _slot.amount == 1 ? "" : _slot.amount.ToString("n0"); // If there is only 1 item on a stack, dont show the number
        } else {
            slotImage.sprite = null;
            slotImage.color = new Color(1, 1, 1, 0);
            _slot.slotDisplay.GetComponentInChildren<Text>().text = "";
        }
    }
    // Update is called once per frame
    /*void Update() {
        // change this later so that display only updates when changes happen, not every frame
        slotsOnInterface.UpdateSlotDisplay();
    }*/
    public abstract void CreateSlots();
    // Code for Trigger Events
    protected void AddEvent(GameObject obj, EventTriggerType triggerType, UnityAction<BaseEventData> action) {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = triggerType;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void OnEnter(GameObject obj) {
        MouseData.slotHoveredOver = obj;
    }
    public void OnExit(GameObject obj) {
        MouseData.slotHoveredOver = null;
    }
    public void OnEnterInterface(GameObject obj) {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj) {
        MouseData.interfaceMouseIsOver = null;
    }
    public void OnDragStart(GameObject obj) {
        MouseData.tempItemBeingDragged = CreateTempItem(obj);
    }
    public GameObject CreateTempItem(GameObject obj) {
        // Creates a temporary "item", or rather, creates the temp item that the player sees when they drag an item from a slot.
        GameObject tempItem = null;
        if (slotsOnInterface[obj].item.Id >= 0) {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(25, 25);
            tempItem.transform.SetParent(transform.parent);
            // Add the sprite
            var img = tempItem.AddComponent<Image>();
            img.sprite = slotsOnInterface[obj].ItemObject.itemIcon;
            img.raycastTarget = false;
        }
        return tempItem;
    }
    public void OnDragEnd(GameObject obj) {
        Destroy(MouseData.tempItemBeingDragged);
        // Check if the input was let go over a slot or not
        if (MouseData.slotHoveredOver) {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            inventory.SwapItems(slotsOnInterface[obj], mouseHoverSlotData);
        }
    }
    public void OnDrag(GameObject obj) {
        if (MouseData.tempItemBeingDragged != null) {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
}

public static class MouseData {
    // This class is used to hold information about what the mouse(or touch input) is currently over.
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
}

public static class ExtensionMethods {
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface) {
        // Updates the slots
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in _slotsOnInterface) {
            var slotImage = _slot.Key.transform.GetChild(0).GetComponent<Image>();

            if (_slot.Value.item.Id >= 0) {
                slotImage.sprite = _slot.Value.ItemObject.itemIcon;
                slotImage.color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<Text>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            } else {
                slotImage.sprite = null;
                slotImage.color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<Text>().text = "";
            }
        }
    }
}
