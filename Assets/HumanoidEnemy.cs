using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class HumanoidEnemy : BaseEnemy
{
    private NavMeshAgent agent;
    [SerializeField] private float walkRadius = 50f;
    [SerializeField] private float distance = float.MaxValue;
    private Vector3 currentTarget = Vector3.zero;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, currentTarget);
        if (distance < 10 || currentTarget == Vector3.zero)
        {
            currentTarget = RandomNavmeshLocation(walkRadius);
            agent.SetDestination(currentTarget);
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
