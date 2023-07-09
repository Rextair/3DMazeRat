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
        fridgePrefab.transform.position = fridgeSpawnPoint.position; fridgePrefab.transform.rotation = fridgeSpawnPoint.rotation;

         Vector3 ratSpawnPoint = GetComponent<SpawnManager>().GetRatSpawnPoint(fridgeSpawnPoint.position);

    // // Создайте крысу на позиции ratSpawnPoint
        Instantiate(ratPrefab, ratSpawnPoint, Quaternion.identity);
    }
}
