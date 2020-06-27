using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDelayTimer : MonoBehaviour
{
    [SerializeField] private GameObject textObj;
    private string timeText;
    private bool isFirstTime = true;
    public static bool canClick = false;


    private void Start()
    {
       
    }
    void Update()
    {
      if(ButtonsManager.isGameStart && isFirstTime)
        {
            StartCoroutine(StartDelay());
         
            isFirstTime = false;
        }
    }

    private IEnumerator StartDelay()
    {
        textObj.GetComponent<Text>().text = "Ready..";
        yield return new WaitForSeconds(0.001f * 1f);
        textObj.GetComponent<Text>().text = "Go";
        yield return new WaitForSeconds(0.001f * 1f);
        textObj.GetComponent<Text>().text = " ";
        Time.timeScale = 1;
        canClick = true;
    }
}
