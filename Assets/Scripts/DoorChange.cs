using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChange : MonoBehaviour
{
    [Header("Map")]
    public GameObject doctorMap;
    public GameObject ballerinaMap;

    [Header("Doorways")]
    public GameObject[] doctorDoors;   
    public GameObject[] ballerinaDoors;

    [Header("NamePlates")]
    public GameObject docNameplate;
    public GameObject balNameplate;

    [Header("Materials")]
    Renderer rend;
    public Material redMat;
    public Material greenMat;
    public Material blueMat;

    [Header("NPC's")]
    public GameObject docNPC;
    public GameObject balNPC;

    private void Start()
    {
        foreach (var obj in doctorDoors)
        {
            obj.GetComponent<Renderer>().sharedMaterial = blueMat;
        }

        foreach (var obj in ballerinaDoors)
        {
            obj.GetComponent<Renderer>().sharedMaterial = blueMat;
        }

        docNameplate.SetActive(false);
        balNameplate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Door0DoctorChange")
        {
            foreach (var obj in doctorDoors)
            {
                obj.GetComponent<Renderer>().sharedMaterial = greenMat;
            }

            foreach (var obj in ballerinaDoors)
            {
                obj.GetComponent<Renderer>().sharedMaterial = redMat;
            }

            doctorMap.SetActive(true);
            ballerinaMap.SetActive(false);

            docNameplate.SetActive(true);
            balNameplate.SetActive(false);

            docNPC.SetActive(true);
            balNPC.SetActive(false);

        }

        if (other.name == "DocNPCSpawn")
        {
            docNPC.SetActive(true);
            balNPC.SetActive(false);
        }

        if (other.name == "Door1BallerinaChange")
        {
            foreach (var obj in ballerinaDoors)
            {
                obj.GetComponent<Renderer>().sharedMaterial = greenMat;
            }

            foreach (var obj in doctorDoors)
            {
                obj.GetComponent<Renderer>().sharedMaterial = redMat;
            }

            ballerinaMap.SetActive(true);
            doctorMap.SetActive(false);

            docNameplate.SetActive(false);
            balNameplate.SetActive(true);

            
        }

        if (other.name == "BelNPCSpawn")
        {
            balNPC.SetActive(true);
            docNPC.SetActive(false);
        }
    }
}
