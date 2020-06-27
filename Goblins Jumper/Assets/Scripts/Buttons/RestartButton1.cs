using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : Button{

    public RestartButton(GameObject buttonObj) : base(buttonObj)
    {
    }

    public override void OnPush(GameObject[] mustEnabledObj=null, GameObject[] mustDisabledObj=null)
    {
        Time.timeScale = 1;
        PlayerController.isAlive = true;
        PlayerController.firstJump = false;
        StartDelayTimer.canClick = false;
        Score.Set(0);
        SpawnerController.platformSpawnCount = 0;
        ButtonsManager.isGameStart = false;
        SceneManager.LoadScene("PlayScene");

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
