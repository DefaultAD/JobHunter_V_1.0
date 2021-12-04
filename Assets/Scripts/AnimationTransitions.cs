using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransitions : MonoBehaviour
{
    public GameManager gameManager;

    public Animator animationFail;
    public Animator animationWin;

    public GameObject scoreCanvas;
    public GameObject playerOne;
    public GameObject newPosition;

    public Camera mainCam;
    public Camera endCam;

    // Start is called before the first frame update
    void Start()
    {
        animationFail.SetBool("isWalking", true);
        animationFail.SetBool("isDancing", false);

        animationWin.SetBool("isWalking", true);
        animationWin.SetBool("isDancing", false);

        scoreCanvas.gameObject.SetActive(true);

        mainCam.gameObject.SetActive(true);
        endCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator animationWait()
    {
        yield return new WaitForSeconds(1.5f);

        animationFail.SetBool("isDancing", true);
        animationFail.SetBool("isDefeated", false);

        //animationWin.SetBool("isVictorius", true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalDoor")
        {
            gameManager.playerMovementScript.movementLimit = 0;
            gameManager.playerMovementScript.touchSensitivity = 0;
        }

        if (other.tag == "EndLevelScene")
        {
            playerOne.transform.position = newPosition.transform.position;

            endCam.gameObject.SetActive(true);
            mainCam.gameObject.SetActive(false);
            scoreCanvas.gameObject.SetActive(false);

            animationFail.SetBool("isDefeated", true);
            animationFail.SetBool("isDancing", false);
            animationFail.SetBool("isWalking", false);

            animationWin.SetBool("isDancing", true);
            animationWin.SetBool("isWalking", false);
            animationWin.SetBool("isVictorius", false);

            StartCoroutine(animationWait());

            //gameManager.playerMovementScript.movementLimit = 0;
            gameManager.playerMovementScript.movementSpeed = 0;
            //gameManager.playerMovementScript.touchSensitivity = 0;

            
            
        }        
    }
}
