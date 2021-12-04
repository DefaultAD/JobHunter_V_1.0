using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public ParticleSystem particlePlumber;
    public ParticleSystem particlePowerUp;
    public ParticleSystem particleWin;

    [Header("Character Gameobjects")]
    public GameObject nakedPlayer;
    public GameObject doc1;
    public GameObject doc2;
    public GameObject doc3;
    public GameObject bel1;
    public GameObject bel2;
    public GameObject bel3;

    bool nakedPlayerActive;
    bool doc1Active;
    bool doc2Active;
    bool doc3Active;
    bool bel1Active;
    bool bel2Active;
    bool bel3Active;

    [Header("Door GameObjects")]
    public GameObject suit;
    public GameObject shoes;
    public GameObject toTo;
    public GameObject coat;
    public GameObject hat;
    public GameObject doctorBag;

    public bool scoreDocCheck;
    public bool scoreBalCheck;


    void Start()
    {
        currentScore = 0;
        scoreBar.SetMaxScore(maxScore);

        scoreDocCheck = false;
        scoreBalCheck = false;

        nakedPlayerActive = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "DoctorPickUp" && scoreDocCheck == true)
        {
            TakeScore(PickUpValue);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "DoctorPickUp" && scoreBalCheck == true)
        {
            TakeScore(-PickUpValue);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "BallerinaPickUp" && scoreBalCheck == true)
        {
            TakeScore(PickUpValue);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "BallerinaPickUp" && scoreDocCheck == true)
        {
            TakeScore(-PickUpValue);
            other.gameObject.SetActive(false);
        }


        if (other.tag == "PickUp1")
        {
            Instantiate(particlePlus, particlesPosition.transform.position, Quaternion.identity);
            
            if (scoreDocCheck == true)
            {
                TakeScore(PickUpValue);
                Debug.Log(currentScore);
            }
            else if (scoreBalCheck == true)
            {
                TakeScore(-PickUpValue);
                Debug.Log(currentScore);
            }
            other.gameObject.SetActive(false);

            
        }

        if (other.tag == "PickUp2")
        {
            Instantiate(particlePlus, particlesPosition.transform.position, Quaternion.identity);

            if (scoreBalCheck == true)
            {
                TakeScore(PickUpValue);
                Debug.Log(currentScore);
            }
            else if (scoreDocCheck == true)
            {
                TakeScore(-PickUpValue);
                Debug.Log(currentScore);
            }

            other.gameObject.SetActive(false);
        }

        if (other.tag == "DoctorDoor")
        {
            Instantiate(particlePowerUp, particlesPosition.transform.position, Quaternion.identity);
            
            Debug.Log(currentScore);

            if (other.gameObject.name == "Door0DoctorChange")
            {
                Debug.Log("Color check!");
                scoreDocCheck = true;
                scoreBalCheck = false;                
            }

            if (other.gameObject.name == "Door2")
            {
                doc1Active = true;
                DeactivateCostumes();
            }
            if (other.gameObject.name == "Door5")
            {
                doc2Active = true;
                DeactivateCostumes();
            }
            if(other.gameObject.name == "Door6")
            {
                win = true;
                doc3Active = true;
                DeactivateCostumes();
            }

            if (scoreDocCheck == true)
            {
                TakeScore(CorrectDoorValue);
            }
            else if (scoreBalCheck == true)
            {
                TakeScore(-CorrectDoorValue);
            }
        }

        if (other.tag == "BallerinaDoor")
        {            
            Instantiate(particleHearts, particlesPosition.transform.position, Quaternion.identity);

            Debug.Log(currentScore);

            if(other.gameObject.name == "Door1BallerinaChange")
            {
                Debug.Log("Color check!");
                scoreDocCheck = false;
                scoreBalCheck = true;
            }

            if (other.gameObject.name == "Door3")
            {
                DeactivateCostumes();

                suit.SetActive(false);
            }

            if (other.gameObject.name == "Door4")
            {
                bel1Active = true;
                DeactivateCostumes();

                toTo.SetActive(false);
            }

            if (other.gameObject.name == "Door7")
            {
                bel2Active = true;
                DeactivateCostumes();

                shoes.SetActive(false);
            }                       

            if (scoreBalCheck == true)
            {
                TakeScore(CorrectDoorValue);
            }
            else if (scoreDocCheck == true)
            {
                TakeScore(-CorrectDoorValue);
            }
        }

        if (other.tag == "FinalDoor")
        {
            TakeScore(CorrectDoorValue);
        }

        if (other.tag == "EndLevelScene" && win == true)
        {
            Instantiate(particleWin, particlesPosition.transform.position, Quaternion.identity);
        }

    }

    void TakeScore(int score)
    {
        currentScore += score;

        if (currentScore < 0)
        {
            currentScore = 0;
        }

        scoreBar.SetScore(currentScore);
    }    

    public void DeactivateCostumes()
    {        
        if (nakedPlayerActive == true)
        {
            doc1.gameObject.SetActive(false);
            doc2.gameObject.SetActive(false);
            doc3.gameObject.SetActive(false);
            bel1.gameObject.SetActive(false);
            bel2.gameObject.SetActive(false);
            bel3.gameObject.SetActive(false);

            if (doc1Active == true)
            {
                doc1.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bel1.gameObject.SetActive(false);
                bel2.gameObject.SetActive(false);
                bel3.gameObject.SetActive(false);
            }

            if (doc2Active == true)
            {
                doc2.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bel1.gameObject.SetActive(false);
                bel2.gameObject.SetActive(false);
                bel3.gameObject.SetActive(false);
            }

            if (doc3Active == true)
            {
                doc3.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                bel1.gameObject.SetActive(false);
                bel2.gameObject.SetActive(false);
                bel3.gameObject.SetActive(false);
            }

            if (bel1Active == true)
            {
                bel1.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bel2.gameObject.SetActive(false);
                bel3.gameObject.SetActive(false);
            }

            if (bel2Active == true)
            {
                bel2.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bel1.gameObject.SetActive(false);
                bel3.gameObject.SetActive(false);
            }

            if (bel3Active == true)
            {
                bel2.gameObject.SetActive(true);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                bel1.gameObject.SetActive(false);
                bel2.gameObject.SetActive(false);
            }
        }            

        doc1Active = false;
        doc2Active = false;
        doc3Active = false;
        bel1Active = false;
        bel2Active = false;
    }
}
