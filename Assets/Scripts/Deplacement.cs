using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public GameManager gameManager;

    public float speed;

    public bool betweenDepartAndPointA;
    public bool betweenPointAAndPointB;
    public bool betweenPointBAndPointC;
    public bool betweenPointCAndPointD;
    public bool betweenPointDAndPointE;

    public int whichFloor;

    public Transform depart;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Transform pointE;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<Joueur>().gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false && gameManager.pause == false)
        {
            DeplacementJoueur();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Sol_RezDeChausse")
        {
            whichFloor = 0;
            depart = GameObject.Find("Rez_de_chaussee").transform.GetChild(0).transform;
            pointA = GameObject.Find("Rez_de_chaussee").transform.GetChild(1).transform;
            pointB = GameObject.Find("Rez_de_chaussee").transform.GetChild(2).transform;
            pointC = GameObject.Find("Rez_de_chaussee").transform.GetChild(3).transform;
            pointD = GameObject.Find("Rez_de_chaussee").transform.GetChild(4).transform;
        }
        else if (other.name == "Sol_1erEtage")
        {
            whichFloor = 1;
            depart = GameObject.Find("1er_etage").transform.GetChild(0).transform;
            pointA = GameObject.Find("1er_etage").transform.GetChild(1).transform;
            pointB = GameObject.Find("1er_etage").transform.GetChild(2).transform;
            pointC = GameObject.Find("1er_etage").transform.GetChild(3).transform;
            pointD = GameObject.Find("1er_etage").transform.GetChild(4).transform;
        }
        else if (other.name == "Sol_2emeEtage")
        {
            whichFloor = 2;
            depart = GameObject.Find("2eme_etage").transform.GetChild(0).transform;
            pointA = GameObject.Find("2eme_etage").transform.GetChild(1).transform;
            pointB = GameObject.Find("2eme_etage").transform.GetChild(2).transform;
            pointC = GameObject.Find("2eme_etage").transform.GetChild(3).transform;
            pointD = GameObject.Find("2eme_etage").transform.GetChild(4).transform;
        }
    }

    void DeplacementJoueur()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameManager.Joueur.GetComponent<Joueur>().playerAnimator.SetBool("IsWalk", true);

            if (transform.position.x >= depart.position.x && transform.position.x < pointA.position.x)
            {
                transform.LookAt(pointA);
            }
            else if (transform.position.x >= pointA.position.x && transform.position.x < pointB.position.x)
            {
                transform.LookAt(pointB);
            }
            else if (transform.position.x >= pointB.position.x && transform.position.x < pointC.position.x)
            {
                transform.LookAt(pointC);
            }
            else if (transform.position.x >= pointC.position.x && transform.position.x < pointD.position.x)
            {
                transform.LookAt(pointD);
            }
            else if (transform.position.x >= pointD.position.x && transform.position.x < pointE.position.x)
            {
                transform.LookAt(pointE);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            gameManager.Joueur.GetComponent<Joueur>().playerAnimator.SetBool("IsWalk", true);

            if (transform.position.x > depart.position.x && transform.position.x <= pointA.position.x)
            {
                transform.LookAt(depart);
            }
            else if (transform.position.x > pointA.position.x && transform.position.x <= pointB.position.x)
            {
                transform.LookAt(pointA);
            }
            else if (transform.position.x > pointB.position.x && transform.position.x <= pointC.position.x)
            {
                transform.LookAt(pointB);
            }
            else if (transform.position.x > pointC.position.x && transform.position.x <= pointD.position.x)
            {
                transform.LookAt(pointC);

            }
            else if (transform.position.x > pointD.position.x && transform.position.x <= pointE.position.x)
            {
                transform.LookAt(pointD);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x >= depart.position.x && transform.position.x < pointA.position.x)
            {
                betweenDepartAndPointA = true;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
            }
            else if (transform.position.x >= pointA.position.x && transform.position.x < pointB.position.x)
            {
                betweenPointAAndPointB = true;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
            }
            else if (transform.position.x >= pointB.position.x && transform.position.x < pointC.position.x)
            {
                betweenPointBAndPointC = true;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
            }
            else if (transform.position.x >= pointC.position.x && transform.position.x < pointD.position.x)
            {
                betweenPointCAndPointD = true;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
            }
            else if (transform.position.x >= pointD.position.x && transform.position.x < pointE.position.x)
            {
                betweenPointDAndPointE = true;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
            }

            if (betweenDepartAndPointA == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            }
            else if (betweenPointAAndPointB == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            }
            else if (betweenPointBAndPointC == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointC.position, speed * Time.deltaTime);
            }
            else if (betweenPointCAndPointD == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointD.position, speed * Time.deltaTime);
            }
            else if (betweenPointDAndPointE == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointE.position, speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (transform.position.x > depart.position.x && transform.position.x <= pointA.position.x)
            {
                betweenDepartAndPointA = true;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
            }
            else if (transform.position.x > pointA.position.x && transform.position.x <= pointB.position.x)
            {
                betweenPointAAndPointB = true;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
            }
            else if (transform.position.x > pointB.position.x && transform.position.x <= pointC.position.x)
            {
                betweenPointBAndPointC = true;
                betweenPointCAndPointD = false;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
            }
            else if (transform.position.x > pointC.position.x && transform.position.x <= pointD.position.x)
            {
                betweenPointCAndPointD = true;
                betweenPointDAndPointE = false;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
            }
            else if (transform.position.x > pointD.position.x && transform.position.x <= pointE.position.x)
            {
                betweenPointDAndPointE = true;
                betweenDepartAndPointA = false;
                betweenPointAAndPointB = false;
                betweenPointBAndPointC = false;
                betweenPointCAndPointD = false;
            }

            if (betweenDepartAndPointA == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, depart.position, speed * Time.deltaTime);
            }
            else if (betweenPointAAndPointB == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            }
            else if (betweenPointBAndPointC == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            }
            else if (betweenPointCAndPointD == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointC.position, speed * Time.deltaTime);
            }
            else if (betweenPointDAndPointE == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointD.position, speed * Time.deltaTime);
            }
        }
        else
        {
            gameManager.Joueur.GetComponent<Joueur>().playerAnimator.SetBool("IsWalk", false);

        }

    }
}
