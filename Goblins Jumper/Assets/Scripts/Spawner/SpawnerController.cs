using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    [SerializeField] private GameObject leftSpawner;
    [SerializeField] private GameObject rightSpawner;

    private PlatformSpawner leftSpawnerScript;
    private PlatformSpawner rightSpawnerScript;

    public static bool isFirstTime;
    public static int platformSpawnCount = 0;

    private enum SpawnedPlatform {Left,Right}
    private SpawnedPlatform lastPlatform;

    private void Start () {
        leftSpawnerScript = leftSpawner.GetComponent<PlatformSpawner>();
        rightSpawnerScript = rightSpawner.GetComponent<PlatformSpawner>();
        lastPlatform = SpawnedPlatform.Right;
        isFirstTime = true;
    }
	
	
	void Update () {
        if(isFirstTime && PlayerController.firstJump)
        {
            SpawnPlatform();          
            isFirstTime = false;        
        }
       

    }
    private void SpawnPlatform()
    {
      
        if(lastPlatform==SpawnedPlatform.Right)
        {
            leftSpawnerScript.Spawn();
            lastPlatform = SpawnedPlatform.Left;
            isFirstTime = false;
            return;
        }
         if (lastPlatform == SpawnedPlatform.Left)
        {
            rightSpawnerScript.Spawn();
            lastPlatform = SpawnedPlatform.Right;
            isFirstTime = false;
            return;
        }
     
    }
}
