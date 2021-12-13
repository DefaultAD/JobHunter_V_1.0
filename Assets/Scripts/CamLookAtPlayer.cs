using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtPlayer : MonoBehaviour
{

    public GameObject playerTarget;
    public GameObject centreTarget;
    public float movementSpeed;
    public GameObject playerPos;
    public float offset;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(gameManager.playerMovementScript.camFollow == false)
        {
            //Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, transform.position.y, playerTarget.transform.position.z);
            Vector3 newPosCamRot = Vector3.Lerp(centreTarget.transform.position, playerTarget.transform.position, 0.05f);
            

            transform.LookAt(newPosCamRot);

            //Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * movementSpeed));
            //transform.position = newPos;

            Vector3 newPos1 = new Vector3(transform.position.x, transform.position.y, playerPos.transform.position.z - offset);
            transform.position = newPos1;
        }
        else if (gameManager.playerMovementScript.camFollow == true)
        {
            return;
        }
    }
}
