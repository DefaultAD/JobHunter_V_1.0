using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpColor : MonoBehaviour
{
    public GameObject greenPickUp;
    public GameObject redPickUp;
    public GameObject pickUp;

    public Player player;

    //public Player player;

    public bool score1PickUpCheck;
    public bool score2PickUpCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Player playerScript = player.GetComponent<Player>();

        score1PickUpCheck = playerScript.scoreDocCheck;
        score2PickUpCheck = playerScript.scoreBalCheck;

        //score1PickUpCheck.Equals(player.scoreDocCheck);
        //score2PickUpCheck.Equals(player.scoreBalCheck);


        //if (player.scoreDocCheck == true)
        //{
        //    pickUpEvent.Invoke();
        //}


        if (score1PickUpCheck == true && pickUp.tag == "PickUp1")
        {
            greenPickUp.SetActive(true);
            redPickUp.SetActive(false);
        }
        else if (score1PickUpCheck == true && pickUp.tag == "PickUp2")
        {
            greenPickUp.SetActive(false);
            redPickUp.SetActive(true);
        }

        if (score2PickUpCheck == true && pickUp.tag == "PickUp2")
        {
            greenPickUp.SetActive(true);
            redPickUp.SetActive(false);
        }

        if (score2PickUpCheck == true && pickUp.tag == "PickUp1")
        {
            greenPickUp.SetActive(false);
            redPickUp.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUp.SetActive(false);
        }
    }
}
