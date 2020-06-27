using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    private GameObject player;
      

	private void Start () {
        player = GameObject.FindGameObjectWithTag("Player");   
	}

	private void Update () {
        transform.position = new Vector2(transform.position.x, player.transform.position.y+2);
    
	}
}
