using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotController : MonoBehaviour
{
    public static BotController instance;
    public Transform target; 

    private NavMeshAgent agent;
    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        Transform newTrans = SpawnManager.instance.GetBotSpawnPoint();
        transform.position = newTrans.position; transform.rotation = newTrans.rotation;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    private void Update()
    {

    }
}

