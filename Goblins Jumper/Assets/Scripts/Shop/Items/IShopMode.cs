using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopMode  {
    Iitem[] GetItems();
    Vector2 GetAttachedPosition();

}
