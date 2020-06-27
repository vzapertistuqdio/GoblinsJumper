using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private void Update () {
        Show();
	}

    public void Show()
    {
        
    }
    public void Add(string name)
    {
        if (CheckItemOnInventory(name))
        {
            Debug.Log("Данная вещь имеется в инвентаре");
        }
        else
        {
            PlayerPrefs.SetString("Inventory", PlayerPrefs.GetString("Inventory") + " " + "(" + name + ")");
            PlayerPrefs.Save();
        }
    }
    public bool CheckItemOnInventory(string name)
    {
        string inventoryItems = PlayerPrefs.GetString("Inventory");
        return inventoryItems.Contains(name);
    }
}
