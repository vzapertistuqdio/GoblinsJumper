using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner:MonoBehaviour  {

    [SerializeField] private GameObject platformPrefab;
    private GameObject platformObj;
    private GameObject player;
    private float deltaHeight = 1f;
    private float startPositioOffset = -4f;
   
    public static Transform currentPlayerPlatform;

    public void Spawn()
    {    
         transform.position = new Vector2(transform.position.x, startPositioOffset + SpawnerController.platformSpawnCount*deltaHeight);      
        platformObj = Instantiate(platformPrefab) as GameObject;
        platformObj.transform.position = transform.position;
        SpawnerController.platformSpawnCount++;
    }
}
