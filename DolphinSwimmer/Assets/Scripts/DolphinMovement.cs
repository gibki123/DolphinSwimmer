using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinMovement : MonoBehaviour
{
    public Vector3 swimForce;
    public float swimSpeed = 500f;

    private Rigidbody rb;
    // Update is called once per frame
    void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(swimSpeed, 0);
        enabled = false;
        rb.useGravity = false;
    }

    void Update()
    {
        if(Input.GetButton("Fire1")) {
            rb.AddForce(swimForce * Time.deltaTime);
        }
    }
}
