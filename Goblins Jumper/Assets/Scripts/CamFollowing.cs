using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowing : MonoBehaviour {

    private GameObject mainCam;
    private Vector2 lastPosition;
    [SerializeField] private GameObject camBorder1;
    [SerializeField] private GameObject camBorder2;
    private float yCamOffset = 1;
   

    void Start () {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        lastPosition = transform.position;

    }
	
	
	void Update () { 
        mainCam.transform.position = new Vector3(mainCam.transform.position.x, transform.position.y+yCamOffset, transform.position.z-10);    
        camBorder1.transform.position = new Vector3(camBorder1.transform.position.x, transform.position.y + 2, transform.position.z );
        camBorder2.transform.position = new Vector3(camBorder2.transform.position.x, transform.position.y + 2, transform.position.z );
        if(PlayerController.isAlive==false)
        {
            camBorder1.SetActive(false);
            camBorder2.SetActive(false);
        }
    }
}
