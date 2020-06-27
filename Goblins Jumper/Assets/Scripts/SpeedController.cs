using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {

    private static float speed;
	
	void Update () {

        speed = 3 + CalculateKoefficient();
    }
    public static float GetSpeed()
    {
        return speed;
    }
    private float CalculateKoefficient()
    {
        float k= Score.Get() / 100;
        if (k>2)
        {
            k = 2;
        }
       return (Score.Get()* k) / 100;
    }
}
