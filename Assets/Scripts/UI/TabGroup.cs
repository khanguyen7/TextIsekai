using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This class is for a Tab Container.

public class TabGroup : MonoBehaviour {

    public GameController gameController;
    public PanelGroup panelGroup;

    public List<TabButton> tabButtons; // A list containing all child Tabs to the current TabGroup
    public List<GameObject> objectsToSwap; // A List that contains the game objects that will be set active or inactive.
    // State Sprites
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    // Variables
    protected TabButton selectedTab;
    public bool CurrentTabAlreadySelected = false;
    int currentDefaultTabIndex;


    public void Subscribe(TabButton button) {
        // This method subscribes/adds a button into tabButtons
        if (tabButtons == null) {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }
    // The following methods change the sprites of the buttons based on their current 'state'.
    public void OnTabEnter(TabButton button) {
        // This method is called when the user hovers over a button.
        ResetTabs();
        if (selectedTab == null || button != selectedTab) {
            button.background.sprite = tabHover;
            CurrentTabAlreadySelected = false;
        }
        else if (selectedTab == button) {
            CurrentTabAlreadySelected = true;
        }
    }
    public void OnTabExit(TabButton button) {
        ResetTabs();
        CurrentTabAlreadySelected = false;
    }
    public void OnTabSelected(TabButton button) {
        if (selectedTab != null) {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        CurrentTabAlreadySelected = true;

        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        panelGroup.SetPageIndex(index);
    }   
    public void OnTabDeselected(TabButton button) {
        if (selectedTab != null) {
            selectedTab.Deselect();
        }
        selectedTab = null;
        ResetTabs();
        button.background.sprite = tabIdle;
        panelGroup.SetPageIndex(currentDefaultTabIndex);
        CurrentTabAlreadySelected = false;
    }
    public void ResetTabs() {
        foreach (TabButton button in tabButtons) {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
    public void InitializeDefaultPage() {
        
        SetCurrentDefaultPage(gameController.GetCurrentGameState());
        panelGroup.SetPageIndex(currentDefaultTabIndex);
    }
    public void SetCurrentDefaultPage(string gameState) {
        string townWord = "town";
        string battleWord = "battle";

        if (gameState == townWord) {
            currentDefaultTabIndex = 6;
        } else if (gameState == battleWord) {
            currentDefaultTabIndex = 7;
        }
    }
}
