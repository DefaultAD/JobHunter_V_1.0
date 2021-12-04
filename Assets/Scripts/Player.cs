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

    bool nakedPlayerActive;
    bool doc1Active;
    bool doc2Active;
    bool doc3Active;
    bool bal1Active;
    bool bal2Active;
    bool bal3Active;

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

                shoes.SetActive(false);
            }

            if (other.gameObject.name == "Door7")
            {
                bal3Active = true;
                DeactivateCostumes();

                toTo.SetActive(false);
            }                       

            //if (scoreBalCheck == true)
            //{
            //    TakeScore(CorrectDoorValue);
            //}
            //else
            //{
            //    TakeScore(-CorrectDoorValue);
            //}

            //else if (scoreDocCheck == true)
            //{
            //    TakeScore(-CorrectDoorValue);
            //}
        }

        //if (other.tag == "FinalDoor")
        //{
        //    TakeScore(CorrectDoorValue);
        //}

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

        if (currentScore > 100)
        {
            currentScore = 100;
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
                bal2.gameObject.SetActive(true);

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
