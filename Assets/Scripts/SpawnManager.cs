using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Transform[] fridgeSpawnPoints;
    public Transform[] botSpawnPoints;
    private void Awake() 
    {
        instance = this;
    }
   
    private void Start() 
    {
        foreach(Transform spawn in fridgeSpawnPoints)
        {
            spawn.gameObject.SetActive(false);
        }
        foreach(Transform spawns in botSpawnPoints)
        {
            spawns.gameObject.SetActive(false);
        }
    }
    public Transform GetFridgeSpawnPoint()
    {
        return fridgeSpawnPoints[Random.Range(0, fridgeSpawnPoints.Length)];
    }
    public Transform GetBotSpawnPoint()
    {
        return botSpawnPoints[Random.Range(0, botSpawnPoints.Length)];
    }
    public Vector3 GetRatSpawnPoint(Vector3 fridgePosition)
{
    Vector3 spawnOffset = new Vector3(0f, 0f, -2f); 

    Vector3 spawnPoint = fridgePosition + spawnOffset;
    Quaternion spawnRotation = Quaternion.identity; 

    return spawnPoint;
}

}
