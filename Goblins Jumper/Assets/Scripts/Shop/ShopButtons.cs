using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour {

    public ShowMoney showMoney;

    private Inventory inventroy;
    private ClothingDisplayOnPlayer displayScript;
    private Shop shop;

    [SerializeField] private GameObject buyBtn;
    [SerializeField] private GameObject equipBtn;

    private void Start () {
        inventroy = GetComponent<Inventory>();
        displayScript = GetComponent<ClothingDisplayOnPlayer>();
        shop = GetComponent<Shop>();
	}
	
	
	private void Update () {
        if (inventroy.CheckItemOnInventory(displayScript.GetCurrentShowItemName()))
        {
            buyBtn.SetActive(false);
            equipBtn.SetActive(true);
        }
        else
        {
            buyBtn.SetActive(true);
            equipBtn.SetActive(false);
        }
    }

    public void OnButBtnClick()
    {
        if (displayScript.GetCurrentShowItemCost() <= PlayerPrefs.GetInt("Money"))
        {
            inventroy.Add(displayScript.GetCurrentShowItemName());
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - displayScript.GetCurrentShowItemCost());
            showMoney.UpdateScript();
        }
        else Debug.Log("Noy enought money");
    }
    public void OnEquipBtnClick()
    {
        if(shop.GetCurrentMode().GetType()==typeof(HatShopMode))
          PlayerPrefs.SetString("Hat", displayScript.GetCurrentShowItemName());
        if (shop.GetCurrentMode().GetType() == typeof(BodyShopMode))
            PlayerPrefs.SetString("Body", displayScript.GetCurrentShowItemName());
        PlayerPrefs.Save();
    }
    public void OnExitBtnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
