using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{
    Health health;
    ParticleSystem particleSystem;
    [SerializeField] float despawnDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        particleSystem = GetComponent<ParticleSystem>();
        health.OnDeath += Health_OnDeath;
    }

    private void Health_OnDeath(object sender, System.EventArgs e)
    {
        particleSystem.Play();
    }

    protected void OnDestroy()
    {
        
    }
}
