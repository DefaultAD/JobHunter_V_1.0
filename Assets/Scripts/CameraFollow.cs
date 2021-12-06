using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtPlayer = false;

    private void Start()
    {
        cameraOffset = transform.position - playerTransform.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 docPosition = playerTransform.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, docPosition, smoothFactor);

        if (lookAtPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
