﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBooster : MonoBehaviour {

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.isAlive = false;
        }
    }
}
