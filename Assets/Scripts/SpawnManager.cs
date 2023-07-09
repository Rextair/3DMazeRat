using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Transform[] fridgeSpawnPoints;
    public Transform[] botSpawnPoints;
    public Transform[] bonusSpawnPoints;
    public GameObject bonusPrefab;
    private void Awake() 
    {
        instance = this;
    }
   
    private void Start()
    {
        DeactivateObjectsInStart();
        SpawnBonuses();
    }

    private void DeactivateObjectsInStart()
    {
        foreach (Transform spawn in fridgeSpawnPoints)
        {
            spawn.gameObject.SetActive(false);
        }
        foreach (Transform spawns in botSpawnPoints)
        {
            spawns.gameObject.SetActive(false);
        }
        foreach (Transform bonus in bonusSpawnPoints)
        {
            bonus.gameObject.SetActive(false);
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
    public Transform GetBonusSpawnPoint()
    {
        return bonusSpawnPoints[Random.Range(0, bonusSpawnPoints.Length)];
    }
    public Vector3 GetRatSpawnPoint(Vector3 fridgePosition)
    {
    Vector3 spawnOffset = new Vector3(0, -.191f, 0f); 

    Vector3 spawnPoint = fridgePosition + spawnOffset;
    Quaternion spawnRotation = Quaternion.identity; 

    return spawnPoint;
    }
    private void SpawnBonuses()
    {
        int numBonuses = Random.Range(1, 4); 

        for (int i = 0; i < numBonuses; i++)
        {
            Transform bonusSpawnPoint = GetRandomAvailableBonusSpawnPoint();
            if (bonusSpawnPoint != null)
            {
                GameObject bonus = Instantiate(bonusPrefab, bonusSpawnPoint.position, bonusSpawnPoint.rotation);
                bonus.gameObject.SetActive(true);
            }
        }
    }

    private Transform GetRandomAvailableBonusSpawnPoint()
    {
        List<Transform> availableSpawnPoints = new List<Transform>();

        foreach (Transform spawnPoint in bonusSpawnPoints)
        {
            if (!spawnPoint.gameObject.activeSelf)
            {
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            return availableSpawnPoints[randomIndex];
        }

        return null;
    }
}

