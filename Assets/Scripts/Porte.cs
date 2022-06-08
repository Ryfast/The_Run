using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public GameManager gameManager;

    public bool canBeUsed = false;

    public string floorDoor;

    public Vector3 playerPosition;

    private void Start()
    {
        floorDoor = gameObject.name;
    }

    private void Update()
    {
        if (gameManager.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Z) && canBeUsed)
            {
                switch (floorDoor)
                {
                    case "Porte_RezDeChausse_End":
                        playerPosition = GameObject.Find("Porte_1erEtage_Start").transform.TransformPoint(0, 3.07f, -4);
                        gameManager.Joueur.transform.position = playerPosition;
                        break;
                    case "Porte_1erEtage_Start":
                        playerPosition = GameObject.Find("Porte_RezDeChausse_End").transform.TransformPoint(0, 3.07f, -4);
                        gameManager.Joueur.transform.position = playerPosition;
                        break;
                    case "Porte_1erEtage_End":
                        playerPosition = GameObject.Find("Porte_2emeEtage_Start").transform.TransformPoint(0, 3.07f, -4);
                        gameManager.Joueur.transform.position = playerPosition;
                        break;
                    case "Porte_2emeEtage_Start":
                        playerPosition = GameObject.Find("Porte_1erEtage_End").transform.TransformPoint(0, 3.07f, -4);
                        gameManager.Joueur.transform.position = playerPosition;
                        break;
                    case "Porte_2emeEtage_End":
                        playerPosition = GameObject.Find("Porte_RezDeChausse_Start").transform.TransformPoint(0, 3.07f, -4);
                        gameManager.Joueur.transform.position = playerPosition;
                        break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Joueur")
        {
                canBeUsed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Joueur")
        {
            canBeUsed = false;
        }

    }
}
