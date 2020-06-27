using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{

    private GameObject buttonObj;

    public Button(GameObject buttonObj)
    {
        this.buttonObj = buttonObj;
    }

    public enum ButtonActive { Enabled, Disabled }

    public void SetActive(ButtonActive state)
    {
        
        if (state == ButtonActive.Enabled)
            buttonObj.SetActive(true);
        if (state == ButtonActive.Disabled)
            buttonObj.SetActive(false);
    }
    public abstract void OnPush(GameObject[] mustEnabledObj=null, GameObject[] mustDisabledObj=null);

   
}
