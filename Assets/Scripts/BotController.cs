using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotController : MonoBehaviour
{
    public static BotController instance;
    public Transform target;

    private NavMeshAgent agent;
    private void Awake()
    {
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
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        GameObject[] mice = GameObject.FindGameObjectsWithTag("Mouse");

        if (mice.Length == 0)
        {
            agent.SetDestination(target.position);
            return;
        }

        GameObject closestMouse = mice[0];
        float closestDistance = Vector3.Distance(transform.position, closestMouse.transform.position);
        foreach (GameObject mouse in mice)
        {
            float distance = Vector3.Distance(transform.position, mouse.transform.position);
            if (distance < closestDistance)
            {
                closestMouse = mouse;
                closestDistance = distance;
            }
        }

        Vector3 mouseDirection = closestMouse.transform.position - transform.position;
        Vector3 blockDirection = Vector3.Cross(mouseDirection, Vector3.up).normalized;
        Vector3 blockPosition = closestMouse.transform.position + blockDirection * 2f;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(blockPosition, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }
}

