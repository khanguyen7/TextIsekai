using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : UserInterface {
    // The DynamicInterface class is used for inventory UI that has a dynamic amount of slots.
    public GameObject slotPrefab;
    public override void CreateSlots() {
        //slotsOnInterface = new Dictionary<GameObject, InventorySlot>(); // Just making sure we have a fresh dictionary and are not using another dictionary with stuff already in it.

        for (int i = 0; i < inventory.GetSlots.Length; i++) {
            var obj = Instantiate(slotPrefab, transform);
            // Add events to the slot
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            inventory.GetSlots[i].slotDisplay = obj;
            // Add the slot to the dictionary, with the prefab object as the key
            slotsOnInterface.Add(obj, inventory.GetSlots[i]);
        }
    }
}
