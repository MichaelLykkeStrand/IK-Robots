using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimationController : MonoBehaviour
{
    protected Animator animator;
    Vector3 pos, velocity;
    [SerializeField] private Transform root;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        velocity = (root.position - pos) / Time.deltaTime;
        pos = root.position;

        animator.SetFloat("Speed", velocity.magnitude);
    }
}
