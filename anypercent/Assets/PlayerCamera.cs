using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    // public Vector3 rotationOffset;

    void LateUpdate()
    {
        if (target)
        {
            Vector3 desiredPosition = target.position + Quaternion.identity * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    void FixedUpdate()
    {

    }
}
