using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float touchSensitivity = 0.0125f;
    [SerializeField] public float movementLimit;

    public bool initialized;

    public float cameraOffset;
    Touch touch;

    public void Start()
    {
        initialized = true;
    }

    private void Update()
    {
        if (initialized)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * movementSpeed));
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, newPos.z - cameraOffset);

            transform.position = newPos;

            if(Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    float xpos = transform.position.x + touch.deltaPosition.x * touchSensitivity;
                    transform.position = new Vector3(xpos, transform.position.y, transform.position.z);

                    if (transform.position.x > movementLimit)
                    {
                        transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);
                        return;
                    }

                    if (transform.position.x < -movementLimit)
                    {
                        transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
                        return;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndLevelScene")
        {
            initialized = false;
        }
    }
}
