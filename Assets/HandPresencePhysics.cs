using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    
    public Transform target;
    private Rigidbody _rb;

    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        
        //position
        _rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;
        
        //rotation
        Quaternion rotationDiff = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDiff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDiffInDegree = angleInDegree * rotationAxis;

        _rb.angularVelocity = (rotationDiffInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);

    }
}
