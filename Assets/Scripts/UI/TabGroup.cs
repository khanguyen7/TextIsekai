using System.Collections.Generic;
using UnityEngine;
// This class is for a Tab Container.
public class TabGroup : MonoBehaviour {
    // Dependecies
    public GameController gameController;
    public PanelGroup panelGroup;
    public List<TabButton> tabButtons; // A list containing all child Tabs to the current TabGroup
    public List<GameObject> objectsToSwap; // A List that contains the panels that will be set active or inactive.
    // State Sprites
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    // Variables
    protected TabButton selectedTab;
    public bool CurrentTabAlreadySelected = false;
    int currentDefaultTabIndex;

    public void Subscribe(TabButton tab) {
        // This method subscribes/adds a button into this tabGroup
        if (tabButtons == null) {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(tab);
    }
    // The following methods change the sprites of the buttons based on their current 'state'.
    public void OnTabEnter(TabButton tab) {
        // This method is called when the user hovers over a button.
        ResetTabs();
        if (selectedTab == null || tab != selectedTab) {
            tab.background.sprite = tabHover;
            CurrentTabAlreadySelected = false;
        }
        else if (selectedTab == tab) {
            CurrentTabAlreadySelected = true;
        }
    }
    public void OnTabExit(TabButton tab) {
        ResetTabs();
        CurrentTabAlreadySelected = false;
    }
    public void OnTabSelected(TabButton tab) {
        // Selects the tab pressed and deselects the previous selected tab
        if (selectedTab != null) {
            selectedTab.Deselect();
        }
        selectedTab = tab;
        selectedTab.Select();
        CurrentTabAlreadySelected = true;

        ResetTabs();
        tab.background.sprite = tabActive;
        int index = tab.transform.GetSiblingIndex();
        panelGroup.SetPageIndex(index);
    }   
    public void OnTabDeselected(TabButton tab) {
        // Deselects the currently selected tab
        selectedTab = null;
        ResetTabs();
        tab.background.sprite = tabIdle;
        panelGroup.SetPageIndex(currentDefaultTabIndex); // Changes panel back to current default panel
        CurrentTabAlreadySelected = false;
    }
    public void ResetTabs() {
        // Resets the sprites of each tab to idle except for the currently selected sprite.
        foreach (TabButton button in tabButtons) {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
    public void InitializeDefaultPage() {
        // Sets the default panel based on saved game state
        SetCurrentDefaultPage(gameController.GetCurrentGameState());
        panelGroup.SetPageIndex(currentDefaultTabIndex);
    }
    public void SetCurrentDefaultPage(string gameState) {
        // Sets the default panel based on given gameState
        string townWord = "town";
        string battleWord = "battle";
        // string gatherWord = "gather";
        if (gameState == townWord) {
            currentDefaultTabIndex = 6;
        } else if (gameState == battleWord) {
            currentDefaultTabIndex = 7;
        }
    }
}