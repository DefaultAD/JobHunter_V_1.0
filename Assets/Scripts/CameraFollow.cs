using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform balTransform;
    public Transform docTransform;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtPlayer = false;

    public PlayerMovement playerMovement;
    public Player player;

    private void Start()
    {
        //cameraOffset = transform.position - balTransform.transform.position;
    }

    private void FixedUpdate()
    {
        if (playerMovement.camFollow == true && player.scoreBalCheck == true)
        {
            Vector3 playerPosition = balTransform.transform.position + new Vector3(0, 3, -4.2f);
            transform.position = Vector3.Slerp(transform.position, playerPosition, smoothFactor);

            if (lookAtPlayer)
            {
                transform.LookAt(balTransform);
            }
        }

        if (playerMovement.camFollow == true && player.scoreDocCheck == true)
        {
            Debug.Log("yes it works! fuck yes!");
            Vector3 playerPosition = docTransform.transform.position + new Vector3(0, 3, -4.2f);
            transform.position = Vector3.Slerp(transform.position, playerPosition, smoothFactor);

            if (lookAtPlayer)
            {
                transform.LookAt(docTransform);
            }
        }
    }
}
