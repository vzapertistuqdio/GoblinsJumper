using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour, Iitem
{
    private int cost;
    private string itemName;
    private GameObject obj;
    private Vector2 attachedPosition;
    private Vector2 attachedScale;

    public Hat(string itemName,int cost,GameObject obj, Vector2 attachedPosition, Vector2 attachedScale)
    {
        this.itemName = itemName;
        this.cost = cost;
        this.obj = obj;
        this.attachedPosition = attachedPosition;
        this.attachedScale = attachedScale;
    }

    public Vector2 GetAttachedPosition()
    {
        return attachedPosition;
    }

    public Vector2 GetAttachedScale()
    {
        return attachedScale;
    }

    public int GetCost()
    {
        return cost;
    }

    public string GetName()
    {
        return itemName;
    }

    public GameObject GetObject()
    {
        return obj;
    }
}
