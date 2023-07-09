using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public GameObject bonusPrefab;
    void Start()
    {
        Transform bonusSpawnPoint = GetComponent<SpawnManager>().GetBonusSpawnPoint();
        Instantiate(bonusPrefab, bonusSpawnPoint.position, bonusSpawnPoint.rotation);
    }
}
