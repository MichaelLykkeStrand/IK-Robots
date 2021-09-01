using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class RobotCrawler : MonoBehaviour
{

    public event EventHandler<OnNewTargetEventArgs> OnNewTargetEvent;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, 0);

            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                Vector3 targetPos = ray.GetPoint(distance);
                agent.SetDestination(targetPos);
                OnNewTargetEventArgs eventArgs = new OnNewTargetEventArgs();
                eventArgs.Target = targetPos;
                OnNewTargetEvent?.Invoke(this, eventArgs);
            }

        }
    }

    public class OnNewTargetEventArgs : EventArgs
    {
        public Vector3 Target { get; set; }
    }
}
