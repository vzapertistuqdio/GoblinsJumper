using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private static int value;

    public static void Set(int amount)
    {
        value = amount;
    }

    public static void AddOne()
    {
        value++;
    }

    public static int Get()
    {
        return value;
    }
}
