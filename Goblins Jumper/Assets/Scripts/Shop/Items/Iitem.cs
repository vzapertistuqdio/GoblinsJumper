using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iitem   {
    int GetCost();
    string GetName();
    GameObject GetObject();
    Vector2 GetAttachedPosition();
    Vector2 GetAttachedScale();

}
