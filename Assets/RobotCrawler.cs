using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class RobotCrawler : MonoBehaviour
{
    [SerializeField]private float distance = 500f;
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                agent.SetDestination(hit.point);
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                Debug.Log(hit.point);
                OnNewTargetEventArgs eventArgs = new OnNewTargetEventArgs();
                eventArgs.Target = hit.point;
                OnNewTargetEvent?.Invoke(this, eventArgs);
            }
        }
    }

    public class OnNewTargetEventArgs : EventArgs
    {
        public Vector3 Target { get; set; }
    }
}
