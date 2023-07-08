using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Transform[] ratSpawnPoints;
    public Transform[] botSpawnPoints;
    private void Awake() 
    {
        instance = this;
    }
   
    private void Start() 
    {
        foreach(Transform spawn in ratSpawnPoints)
        {
            spawn.gameObject.SetActive(false);
        }
        foreach(Transform spawns in botSpawnPoints)
        {
            spawns.gameObject.SetActive(false);
        }
    }
    public Transform GetRatSpawnPoint()
    {
        return ratSpawnPoints[Random.Range(0, ratSpawnPoints.Length)];
    }
    public Transform GetBotSpawnPoint()
    {
        return botSpawnPoints[Random.Range(0, botSpawnPoints.Length)];
    }
}
