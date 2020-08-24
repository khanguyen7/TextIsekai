using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// WIP
public class BuyMenu : MonoBehaviour {

    public GameObject leftDisplay;
    public GameObject centerDisplayContent;
    public GameObject rightDisplay;
    public GameObject itemButtonPrefab;
    public GameObject itemInfoPanelPrefab;

    public Button currentButton;

    // Start is called before the first frame update
    void Start() {
        currentButton = null;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void InitializeItems(List<Item> items) {
        foreach (Item item in items) {
            var button = Instantiate(itemButtonPrefab, centerDisplayContent.transform);

            // maybe set new stuff about the button here, e.g. change text and stuff
            button.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        }
    }
    
    public void OnItemButtonPress(Button button) {
        currentButton = button;

    }
}
