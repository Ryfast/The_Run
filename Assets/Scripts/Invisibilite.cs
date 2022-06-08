using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilite : MonoBehaviour
{
    public GameManager gameManager;

    //public Color defaultColor;
    //public Color invisibleColor;

    public Material defaultMaterial;
    public Material groomMaterial;

    public bool powerUp;

    public float cooldown;
    public float invisibilityTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        powerUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false)
        {
            if (Input.GetKeyDown("space") /*&& invisibleOn == false */&& powerUp == true)
            {
                StartCoroutine(Invisible());
            }
        }
    }

    IEnumerator Invisible()
    {
        //invisibleOn = true;
        powerUp = false;
        gameManager.Joueur.GetComponent<Joueur>().playerAnimator.SetBool("PowerActivate", true);
        gameObject.GetComponent<Renderer>().material = groomMaterial;
        gameObject.transform.parent.gameObject.layer = 8;
        gameObject.transform.parent.gameObject.GetComponent<Deplacement>().speed = 1.3f;

        yield return new WaitForSeconds(invisibilityTime);

        gameManager.Joueur.GetComponent<Joueur>().playerAnimator.SetBool("PowerActivate", false);
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
        gameObject.transform.parent.gameObject.layer = 10;
        gameObject.transform.parent.gameObject.GetComponent<Deplacement>().speed = 2;
        //invisibleOn = false;

        yield return new WaitForSeconds(cooldown);

        powerUp = true;
    }
}
