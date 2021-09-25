using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleSpawner : MonoBehaviour
{

    [SerializeField]private GameObject particleSpawner;

    private void Awake()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

}
