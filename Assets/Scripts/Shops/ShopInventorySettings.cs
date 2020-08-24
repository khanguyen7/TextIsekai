using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains all the specific info of a shop, e.g. available items, costs, etc
[CreateAssetMenu(menuName = "Shop Inventory Setting")]
public class ShopInventorySettings : ScriptableObject {

    // Available Items and costs
    public string Item1Name;
    public int Item1Cost;
    public string Item2Name;
    public int Item2Cost;
    public string Item3Name;
    public int Item3Cost;
    public string Item4Name;
    public int Item4Cost;
    public string Item5Name;
    public int Item5Cost;
    public string Item6Name;
    public int Item6Cost;
    public string Item7Name;
    public int Item7Cost;
    public string Item8Name;
    public int Item8Cost;
    public string Item9Name;
    public int Item9Cost;
    public string Item10Name;
    public int Item10Cost;

    public Tuple<string, int> item1;

    public List<int> testList;



}
