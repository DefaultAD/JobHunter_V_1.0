using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreCameraObject : MonoBehaviour
{
    public float movementSpeed;
    public GameObject playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * movementSpeed));
        //transform.position = newPos;

        Vector3 newPos1 = new Vector3(transform.position.x, transform.position.y, playerPos.transform.position.z);
        transform.position = newPos1;
    }
}
