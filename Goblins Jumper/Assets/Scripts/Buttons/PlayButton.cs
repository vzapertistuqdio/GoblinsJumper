using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : Button {

    public PlayButton(GameObject buttonObj) : base(buttonObj)
    {
    }

    public override void OnPush(GameObject[] mustEnabledObj=null, GameObject[] mustDisabledObj=null)
    {
        if (mustEnabledObj != null)
        {
            foreach (GameObject obj in mustEnabledObj)
            {
                obj.SetActive(true);
            }
        }
        if (mustDisabledObj != null)
        {
            foreach (GameObject obj in mustDisabledObj)
            {
                obj.SetActive(false);
            }
        }
      
    }

}
