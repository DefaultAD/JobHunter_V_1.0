using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Score")]
    public ScoreBar scoreBar;
    public int maxScore = 100;
    public int currentScore;
    public bool win;

    [Header("Doorways")]
    public int CorrectDoorValue;
    public int IncorrectDoorValue;
    public int PickUpValue;
    public int ObstacleLoseValue;

    [Header("Particles")]
    public GameObject particlesPosition;
    public ParticleSystem particleHearts;
    public ParticleSystem particlePlus;
    public ParticleSystem particlePowerDown;
    public ParticleSystem particlePowerUp;
    public ParticleSystem particleWin;

    [Header("Character Gameobjects")]
    public GameObject nakedPlayer;
    public GameObject doc1;
    public GameObject doc2;
    public GameObject doc3;
    public GameObject bal1;
    public GameObject bal2;
    public GameObject bal3;
    public GameObject balDoc;

    bool nakedPlayerActive;
    bool doc1Active;
    bool doc2Active;
    bool doc3Active;
    bool bal1Active;
    bool bal2Active;
    bool bal3Active;

    [Header("Door GameObjects")]
    public GameObject suit;
    public GameObject tiara;
    public GameObject toTo;
    public GameObject coat;
    public GameObject hat;
    public GameObject doctorBag;

    public bool scoreDocCheck;
    public bool scoreBalCheck;

    public Text scoreText;

    public bool failRun;
    public bool winRun;

    PlayerMovement playerMovement;


    void Start()
    {
        currentScore = 0;
        scoreBar.SetMaxScore(maxScore);

        scoreDocCheck = false;
        scoreBalCheck = false;

        nakedPlayerActive = true;
        scoreText.text = "Unemployed";
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PickUp1")
        {
                        
            if (scoreDocCheck == true)
            {
                Instantiate(particlePlus, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(PickUpValue);
            }
            else if (scoreBalCheck == true)
            {
                Instantiate(particlePowerDown, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(-PickUpValue);
            }
            other.gameObject.SetActive(false);

            
        }

        if (other.tag == "PickUp2")
        {
            
            if (scoreBalCheck == true)
            {
                Instantiate(particlePlus, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(PickUpValue);
            }
            else if (scoreDocCheck == true)
            {
                Instantiate(particlePowerDown, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(-PickUpValue);
            }

            other.gameObject.SetActive(false);
        }

        if (other.tag == "DoctorDoor")
        {

            if (other.gameObject.name == "Door0DoctorChange")
            {

                Debug.Log("Color check!");
                scoreDocCheck = true;
                scoreBalCheck = false;                
            }

            if (scoreDocCheck != true)
            {
                Instantiate(particlePowerDown, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(-CorrectDoorValue);
            }

            if (scoreDocCheck == true)
            {
                Instantiate(particlePowerUp, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(CorrectDoorValue);
            }

            if (other.gameObject.name == "Door2")
            {
                doc1Active = true;
                DeactivateCostumes();

                coat.SetActive(false);
            }
            if (other.gameObject.name == "Door5")
            {
                doc2Active = true;
                DeactivateCostumes();

                hat.SetActive(false);
            }
            if(other.gameObject.name == "Door6")
            {
                if (scoreDocCheck == true)
                {
                    winRun = true;
                }
                else if (scoreBalCheck == true)
                {
                    failRun = false;
                }

                win = true;
                doc3Active = true;
                DeactivateCostumes();

                doctorBag.SetActive(false);
            }

            //if (scoreDocCheck == true)
            //{
            //    Debug.Log("Score Doctor Check Doctor DOor!");
            //    TakeScore(CorrectDoorValue);
            //}
            //else
            //{
            //    TakeScore(-CorrectDoorValue);
            //}
            //else if (scoreBalCheck == true)
            //{
            //    TakeScore(-CorrectDoorValue);
            //}
        }

        if (other.tag == "BallerinaDoor")
        {   

            if(other.gameObject.name == "Door1BallerinaChange")
            {
                Debug.Log("Color check!");
                scoreDocCheck = false;
                scoreBalCheck = true;
            }

            if (scoreBalCheck != true)
            {
                Instantiate(particlePowerDown, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(-CorrectDoorValue);
            }

            if (scoreBalCheck == true)
            {
                Instantiate(particleHearts, particlesPosition.transform.position, Quaternion.identity);
                TakeScore(CorrectDoorValue);
            }

            if (other.gameObject.name == "Door3")
            {
                bal1Active = true;
                DeactivateCostumes();

                suit.SetActive(false);
            }

            if (other.gameObject.name == "Door4")
            {
                bal2Active = true;
                DeactivateCostumes();

                tiara.SetActive(false);
            }

            if (other.gameObject.name == "Door7")
            {
                if (scoreDocCheck == true)
                {
                    failRun = true;
                }
                else if (scoreBalCheck == true)
                {
                    winRun = true;
                }
                bal3Active = true;
                DeactivateCostumes();

                toTo.SetActive(false);
            }
        }

        //if (other.tag == "FinalDoor")
        //{
        //    TakeScore(CorrectDoorValue);
        //}

        if (other.tag == "EndLevelScene")
        {            
            this.gameObject.transform.Rotate(0f, 180f, 0f, Space.Self);

            if (currentScore > 80)
            {
                Instantiate(particleWin, particlesPosition.transform.position, Quaternion.identity);
            }
            scoreText.gameObject.SetActive(false);
        }

    }

    void TakeScore(int score)
    {
        currentScore += score;

        if (currentScore < 0)
        {
            currentScore = 0;
        }

        if (currentScore > 100)
        {
            currentScore = 100;
        }

        //Doctor Score Text

        if (currentScore <= 15 && scoreDocCheck == true)
        {
            scoreText.text = "Scrub";
        }

        if (currentScore >= 15 && currentScore < 35 && scoreDocCheck == true)
        {
            scoreText.text = "Scrub";
        }

        if(currentScore >= 35 && currentScore < 60 && scoreDocCheck == true)
        {
            scoreText.text = "Nurse";
        }

        if (currentScore >= 60 && currentScore < 80 && scoreDocCheck == true)
        {
            scoreText.text = "Doctor";
        }

        if (currentScore >= 80 && currentScore <= 100 && scoreDocCheck == true)
        {
            scoreText.text = "Surgeon";
        }

        //Ballerina Score Text

        if (currentScore <= 15 && scoreBalCheck == true)
        {
            scoreText.text = "Student";
        }

        if (currentScore >= 15 && currentScore < 35 && scoreBalCheck == true)
        {
            scoreText.text = "Student";
        }

        if (currentScore >= 35 && currentScore < 60 && scoreBalCheck == true)
        {
            scoreText.text = "Novice";
        }

        if (currentScore >= 60 && currentScore < 80 && scoreBalCheck == true)
        {
            scoreText.text = "Intermediate";
        }

        if (currentScore >= 80 && currentScore <= 100 && scoreBalCheck == true)
        {
            scoreText.text = "Ballerina";
        }

        Debug.Log(currentScore);
        scoreBar.SetScore(currentScore);
    }    

    public void DeactivateCostumes()
    {        
        if (nakedPlayerActive == true)
        {
            doc1.gameObject.SetActive(false);
            doc2.gameObject.SetActive(false);
            doc3.gameObject.SetActive(false);
            bal1.gameObject.SetActive(false);
            bal2.gameObject.SetActive(false);
            bal3.gameObject.SetActive(false);

            if (doc1Active == true)
            {
                doc1.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bal1.gameObject.SetActive(false);
                bal2.gameObject.SetActive(false);
                bal3.gameObject.SetActive(false);
            }

            if (doc2Active == true)
            {
                doc2.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bal1.gameObject.SetActive(false);
                bal2.gameObject.SetActive(false);
                bal3.gameObject.SetActive(false);
            }

            if (doc3Active == true)
            {
                doc3.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                bal1.gameObject.SetActive(false);
                bal2.gameObject.SetActive(false);
                bal3.gameObject.SetActive(false);
            }

            if (bal1Active == true)
            {
                bal1.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bal2.gameObject.SetActive(false);
                bal3.gameObject.SetActive(false);
            }

            if (bal2Active == true)
            {
                bal2.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bal1.gameObject.SetActive(false);
                bal3.gameObject.SetActive(false);
            }

            if (bal3Active == true)
            {
                if (winRun == true)
                {
                    bal3.gameObject.SetActive(true);
                }
                else if (failRun == true)
                {
                    balDoc.gameObject.SetActive(true);
                }
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bal1.gameObject.SetActive(false);
                bal2.gameObject.SetActive(false);
            }
        }            

        doc1Active = false;
        doc2Active = false;
        doc3Active = false;
        bal1Active = false;
        bal2Active = false;
    }
}
