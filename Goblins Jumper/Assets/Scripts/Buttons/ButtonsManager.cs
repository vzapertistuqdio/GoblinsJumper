using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

    public ScoreDisplay scoreDisplay;

    [SerializeField] private GameObject playBtnObj;
    [SerializeField] private GameObject restartBtnObj;
    [SerializeField] private GameObject shoptBtnObj;

    private PlayButton playButton;
    private RestartButton restartButton;
    public static bool isGameStart = false;

	private void Start () {
        playButton = new PlayButton(playBtnObj);
        restartButton = new RestartButton(restartBtnObj);
        restartButton.SetActive(Button.ButtonActive.Disabled);
        Time.timeScale = 0;
	}
	

	private void Update () {
		if(PlayerController.isAlive==false)
        {
            PlayerDeadDisplayButtons();
        }
	}


    public void OnPlayButtonClick()
    {      
        GameObject[] mustDisabledObj = { restartBtnObj,shoptBtnObj };
        playButton.OnPush(null, mustDisabledObj);
        StartCoroutine(AnimDelay(playButton));
        isGameStart = true;
        scoreDisplay.isMoneySaved = false;

    }
    public void OnShopButtonClick()
    {
        SceneManager.LoadScene("Shop");
    }
    public void OnRestartButtonClick()
    {
        GameObject[] mustDisabledObj = { playBtnObj,shoptBtnObj };
        restartButton.OnPush(null, mustDisabledObj);
        StartCoroutine(AnimDelay(restartButton));
        
    }

    public void PlayerDeadDisplayButtons()
    {
        StartCoroutine(DeadDelay());
        playButton.SetActive(Button.ButtonActive.Disabled);
        restartButton.SetActive(Button.ButtonActive.Enabled);
    }
    private IEnumerator DeadDelay()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
    public IEnumerator AnimDelay(Button btn)
    {
        Time.timeScale = 0.001f;
        yield return new WaitForSeconds(0.001f*0.1f);
        btn.SetActive(Button.ButtonActive.Disabled);
       
    }
  

}
