using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSpawner : MonoBehaviour
{
    public GameObject fridgePrefab;
    public GameObject ratPrefab;
    private void Awake() 
    {
        Transform fridgeSpawnPoint = GetComponent<SpawnManager>().GetFridgeSpawnPoint();
        Instantiate(fridgePrefab, fridgeSpawnPoint.position, fridgeSpawnPoint.rotation);
        //fridgePrefab.transform.position = fridgeSpawnPoint.position; fridgePrefab.transform.rotation = fridgeSpawnPoint.rotation;

         Vector3 ratSpawnPoint = GetComponent<SpawnManager>().GetRatSpawnPoint(fridgeSpawnPoint.position);
        Instantiate(ratPrefab, ratSpawnPoint, Quaternion.identity);
    }
}
