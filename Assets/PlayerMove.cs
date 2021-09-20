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

        if(dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            rigidbody.velocity = (transform.forward * speed);
        }

    }

}