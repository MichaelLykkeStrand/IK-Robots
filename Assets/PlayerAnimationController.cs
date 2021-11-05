using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform rootTransform;
    Vector3 pos, velocity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = (rootTransform.position - pos) / Time.deltaTime;
        pos = rootTransform.position;

        animator.SetFloat("Speed", velocity.magnitude);
    }
}
