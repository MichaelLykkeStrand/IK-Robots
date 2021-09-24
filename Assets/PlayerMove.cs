using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity = 0.5f;
    private Transform cam;
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;


        Vector3 difference = cam.position - transform.position;
        float yRotation = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yRotation-180, 0), turnSmoothTime);
        

        if(vertical > 0)
        {
            rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        if(vertical < 0)
        {
            rigidbody.MovePosition(transform.position + transform.forward * -speed * Time.deltaTime);
        }
        if(horizontal > 0)
        {
            rigidbody.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
        if(horizontal < 0){
            rigidbody.MovePosition(transform.position + transform.right * -speed * Time.deltaTime);
        }

    }

}