using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatShopMode : MonoBehaviour,IShopMode {

    private List<Hat> hats;

    [SerializeField] private GameObject head;


    public Vector2 GetAttachedPosition()
    {
        return head.transform.position;
    }

    public Iitem[] GetItems()
    {
        Iitem[] tempHats = ItemsDatabase.Get().Hats().ToArray();
        return tempHats;
    }

    private void Start () {
        hats = ItemsDatabase.Get().Hats();
	}
	
	
	private void Update () {
     
     
    }
}
