using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
// This class is related to the TabGroup.cs class. Contains events related to selecting and deselecting a tab button.
[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
    // Variables
    public TabGroup tabGroup;
    public Image background;
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;
    public void OnPointerClick(PointerEventData eventData) {
        if (!tabGroup.CurrentTabAlreadySelected) {
            tabGroup.OnTabSelected(this);        
        } else {
            tabGroup.OnTabDeselected(this);
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        tabGroup.OnTabEnter(this);
    }
    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.OnTabExit(this);
    }
    void Start() {
        // Start is called before the first frame update        
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }
    // The following functions allow for more versitality when it comes to events being triggered by a tab switch. Check the inspector.
    public void Select() {
        if (onTabSelected != null) {
            onTabSelected.Invoke();
        }
    }
    public void Deselect() {
        if (onTabDeselected != null) {
            onTabDeselected.Invoke();
        }
    }
}
