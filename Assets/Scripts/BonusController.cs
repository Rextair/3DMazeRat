using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    RatController ratController;
    void Start()
    {
        ratController = FindObjectOfType<RatController>();
        Transform bonusSpawnPoint = FindObjectOfType<SpawnManager>().GetBonusSpawnPoint();
        transform.position = bonusSpawnPoint.position; transform.rotation = bonusSpawnPoint.rotation;
    }
    private void OnTriggerEnter(Collider target) {
        if(target.gameObject.CompareTag("Player"))
        {
            ratController.currentSpawnCount--; ratController.reverseSpawnCount++;
            // pick up sound
            Destroy(gameObject);
        }
    }
}
