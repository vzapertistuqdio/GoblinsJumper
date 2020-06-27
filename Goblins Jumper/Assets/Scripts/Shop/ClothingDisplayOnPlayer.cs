using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingDisplayOnPlayer : MonoBehaviour,IObserver {

    private Shop shop;
    private IShopMode shopMode;
    private Iitem[] currentModeItems;

    private int itemId;
    private int lastItemId=999;

    private bool isChanged = false;
    private bool isSpawned = false;

    private GameObject spawnItem;

    [SerializeField] private Text costText;

    private void Start () {
        shop = GetComponent<Shop>();
        shop.RegisterObserver(this);        	
	}
	
	private void Update () {

        isChanged=CheckChangesItem();
        if(isChanged)
        {
            if (!isSpawned)
            {
               spawnItem=Instantiate(currentModeItems[itemId].GetObject());
                spawnItem.transform.position = shopMode.GetAttachedPosition();
                if(shopMode.GetType()==typeof(HatShopMode))
                {
                    spawnItem.transform.localScale = new Vector2(1.5f, 1.5f);
                    spawnItem.transform.position = new Vector2(spawnItem.transform.position.x + 0.1f, spawnItem.transform.position.y + 0.2f);
                    if(currentModeItems[itemId].GetName()=="New Year Hat")
                    {
                        spawnItem.transform.position = new Vector2(spawnItem.transform.position.x + 0.1f, spawnItem.transform.position.y + 0.4f);
                    }
                }
                costText.text = currentModeItems[itemId].GetCost().ToString();
            }
        }
    }

    public void SetItemId(int id)
    {
        itemId = id;
    }
    public string GetCurrentShowItemName()
    {
        return currentModeItems[itemId].GetName();
    }
    public int GetCurrentShowItemCost()
    {
        return currentModeItems[itemId].GetCost();
    }

    public void UpdateObservers(IShopMode mode)
    {
        shopMode = mode;
        currentModeItems = shopMode.GetItems();
        lastItemId = 999;

    }

    private bool CheckChangesItem()
    {
        if (lastItemId != itemId)
        {
            lastItemId = itemId;
            isSpawned = false;
            DeleteOldItem();
            return true;
        }
        else return false;
    }
    private void DeleteOldItem()
    {
        Destroy(spawnItem);
    }
}
