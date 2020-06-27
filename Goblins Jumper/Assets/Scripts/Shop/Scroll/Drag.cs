﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    private bool isMouseUp = false;
    private float mousePower;

    [SerializeField] private GameObject scrollImageobject;
    private ScrollImage scrollImage;

    private Camera mainCamera;
    private float centerCameraX,centerCameraY;

    private RectTransform rectTransform;

    private int lastMousePowerDirection = 1;


    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        centerCameraX = mainCamera.pixelWidth / 2;
        centerCameraY = mainCamera.pixelHeight / 2;

        rectTransform = GetComponent<RectTransform>();
        scrollImage = scrollImageobject.GetComponent<ScrollImage>();
    }
	

	void Update () {
        Vector2 mousePos = Input.mousePosition;


   
        if (Input.GetMouseButton(0) && mousePos.y < centerCameraY / 2)
        {
            transform.position = new Vector2(transform.position.x + Input.GetAxis("Mouse X") * 10, transform.position.y);
            mousePower = Input.GetAxis("Mouse X") * 10;
        }
        else if (Input.GetMouseButtonUp(0) && mousePos.y < centerCameraY )
        {
            isMouseUp = true;

        }

        if (isMouseUp)
        {
            ChangeMoveItems();
        }
       
    }

    private void ScrollClampPos()
    {
        if ((transform.position.x + rectTransform.sizeDelta.x / 2) < centerCameraX)
        {
            transform.position = new Vector2(centerCameraX - rectTransform.sizeDelta.x / 2, transform.position.y);
        }
        if ((transform.position.x - rectTransform.sizeDelta.x / 2) > centerCameraX)
        {
            transform.position = new Vector2(centerCameraX + rectTransform.sizeDelta.x / 2, transform.position.y);
        }
    }

    private void ChangeMoveItems()
    {
        if ((int)mousePower != 0)
        {
            ScrollItems(1, 10);
            if (mousePower < 0)
            {
                mousePower = mousePower + Time.deltaTime * 12;
                lastMousePowerDirection = 1;

            }
            else if (mousePower > 0)
            {
                mousePower = mousePower - Time.deltaTime * 12;
                lastMousePowerDirection = -1;

            }
        }
        else if ((int)mousePower == 0)
        {
            if (scrollImage.CheckImageInCenter())
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
            else if (scrollImage.CheckImageInCenter() == false)
            {
                ScrollItems(lastMousePowerDirection, 100);
            }

        }
        ScrollClampPos();
    }


    private void ScrollItems(int direction,float speed)
    {
        transform.position = new Vector2(transform.position.x + mousePower - Time.deltaTime * speed*direction, transform.position.y);
    }
}
