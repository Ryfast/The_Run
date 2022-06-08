using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Deplacement : MonoBehaviour
{
    public GameManager gameManager;

    public float speed;

    public GameObject pointA;
    public GameObject pointB;

    public bool playeurInView = false;
    public bool destinationAReached = false;
    public bool destinationBReached = false;
    public bool onTheWayToA = true;
    public bool onTheWayToB = false;
    public bool dontLookA;
    public bool dontLookB;

    public Animator ennemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playeurInView = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false && gameManager.pause == false)
        {
            if (playeurInView == false)
            {
                if (onTheWayToA == true)
                {
                    destinationBReached = false;

                    if (!destinationAReached)
                    {
                        if (dontLookA == false)
                        {
                            dontLookB = false;
                            transform.eulerAngles = new Vector3(0, 270, 0);
                            dontLookA = true;
                        }

                        transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);

                        if (transform.position.x <= pointA.transform.position.x)
                        {
                            destinationAReached = true;
                            onTheWayToA = false;
                            onTheWayToB = true;
                        }
                    }
                }

                if (onTheWayToB == true)
                {
                    destinationAReached = false;

                    if (!destinationBReached)
                    {
                        if (dontLookB == false)
                        {
                            dontLookA = false;
                            //transform.LookAt(pointA.transform);
                            transform.eulerAngles = new Vector3(0, 90, 0);
                            dontLookB = true;
                        }

                        transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);

                        if (transform.position.x >= pointB.transform.position.x)
                        {
                            destinationBReached = true;
                            onTheWayToB = false;
                            onTheWayToA = true;
                        }
                    }
                }
            }
            else
            {
                transform.LookAt(gameManager.Joueur.transform);
                speed = 2.5f;
                transform.position = Vector3.MoveTowards(transform.position, gameManager.Joueur.transform.position, speed * Time.deltaTime);

            }
        }
    }
}
