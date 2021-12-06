using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransitions : MonoBehaviour
{
    public GameManager gameManager;

    public Animator animationFail;
    public Animator animationBal;
    public Animator animationDoc;

    public GameObject scoreCanvas;
    public GameObject playerOne;
    public GameObject newPositionDoc;
    public GameObject newPositionBal;

    public Camera mainCamera;
        
    // Start is called before the first frame update
    void Start()
    {        
        animationFail.SetBool("isWalking", true);
        animationFail.SetBool("isDancing", false);

        animationDoc.SetBool("isWalking", true);
        animationDoc.SetBool("isDancing", false);

        animationBal.SetBool("isWalking", true);
        animationBal.SetBool("isDancing", false);

        scoreCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator animationWait()
    //{
    //    yield return new WaitForSeconds(1.5f);

    //    animationFail.SetBool("isDancing", true);
    //    animationFail.SetBool("isDefeated", false);

    //    //animationWin.SetBool("isVictorius", true);

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalDoor")
        {
            gameManager.playerMovementScript.movementLimit = 0;
            gameManager.playerMovementScript.touchSensitivity = 0;
        }

        if (other.tag == "EndLevelScene")
        {        
            if (gameManager.playerScript.scoreDocCheck == true)
            {
                //playerOne.transform.position = newPositionDoc.transform.position;                
            }
            if (gameManager.playerScript.scoreBalCheck == true)
            {
                //playerOne.transform.position = newPositionBal.transform.position;
            }

            //mainCamera.gameObject.SetActive(false);
            scoreCanvas.gameObject.SetActive(false);

            animationFail.SetBool("isDancing", true);
            animationFail.SetBool("isWalking", false);

            animationDoc.SetBool("isDancing", true);
            animationDoc.SetBool("isWalking", false);

            animationBal.SetBool("isDancing", true);
            animationBal.SetBool("isWalking", false);

            //StartCoroutine(animationWait());

            //gameManager.playerMovementScript.movementLimit = 0;
            gameManager.playerMovementScript.movementSpeed = 0;
            //gameManager.playerMovementScript.touchSensitivity = 0;

            
            
        }        
    }
}
