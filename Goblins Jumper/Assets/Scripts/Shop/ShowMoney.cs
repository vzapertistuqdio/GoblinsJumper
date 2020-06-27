using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{
    public Text moneyText;
    private void Start()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }
    public void UpdateScript()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }
    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("Money"));
    }
}
