using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReaction : MonoBehaviour {

    private Camera mainCamera;
    private float screenCenterX;

    private GameObject controllerObj;
    private ClothingDisplayOnPlayer displayScript;

    public bool isInCenter = false;

    public int id;




	private void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        screenCenterX = mainCamera.pixelWidth / 2;

        controllerObj = GameObject.FindGameObjectWithTag("GameController");
        displayScript = controllerObj.GetComponent<ClothingDisplayOnPlayer>();
    }
	
	
	private void Update () {

        if (transform.position.x < screenCenterX + 55 && transform.position.x > screenCenterX - 55)
        {
            transform.localScale = new Vector2(2, 2);
            isInCenter = true;
            displayScript.SetItemId(id);

        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            isInCenter = false;
        }

    }
   

}
