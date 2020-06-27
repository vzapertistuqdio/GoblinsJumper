using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    [SerializeField] private GameObject scoreTextObj;
    private string scoreText;

    public bool isMoneySaved = false;

    private void Update () {
        Debug.Log(PlayerPrefs.GetInt("Money"));
        DisplayScore();

        if (PlayerController.isAlive==false)
        {
            if (!isMoneySaved)
            {
                SaveMoney();
                isMoneySaved = true;
            }
            if(PlayerPrefs.GetInt("RecordScore")<Score.Get())
            {
                PlayerPrefs.SetInt("RecordScore", Score.Get());
            }
        }
	}

    private void DisplayScore()
    {
        if (ButtonsManager.isGameStart == false)
        {
            scoreTextObj.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("RecordScore");
        }
        else scoreTextObj.GetComponent<Text>().text = Score.Get().ToString();
    }
    private void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + Score.Get());
    }
}
