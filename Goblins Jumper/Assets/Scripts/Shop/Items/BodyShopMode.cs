using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyShopMode : MonoBehaviour,IShopMode {

    private List<Body> bodyes;

    [SerializeField] private GameObject body;


    public Vector2 GetAttachedPosition()
    {
        return body.transform.position;
    }

    public Iitem[] GetItems()
    {
        Iitem[] tempBodyes = ItemsDatabase.Get().Bodies().ToArray();
        return tempBodyes;
    }


    private void Start()
    {
        bodyes = ItemsDatabase.Get().Bodies();
    }
}
