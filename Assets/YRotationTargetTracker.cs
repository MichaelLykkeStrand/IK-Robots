using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RobotCrawler;

public class YRotationTargetTracker : MonoBehaviour
{
    [SerializeField] private float trackingDistance = 8;
    [SerializeField] private float rotationSpeed = 2;
    private Vector3 target;
    [SerializeField] private RobotCrawler robotCrawler;
    // Start is called before the first frame update
    void Start()
    {
        robotCrawler.OnNewTargetEvent += RobotCrawler_OnNewTargetEvent;
    }

    private void RobotCrawler_OnNewTargetEvent(object sender, OnNewTargetEventArgs e)
    {
        this.target = e.Target;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(target != null)
        {
            float distance = Vector3.Distance(transform.position, target);
            if(distance < trackingDistance)
            {
                // Determine which direction to rotate towards
                Vector3 difference = target - transform.position;
                float yRotation = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, yRotation, 0), rotationSpeed*Time.deltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
        }
    }
}
