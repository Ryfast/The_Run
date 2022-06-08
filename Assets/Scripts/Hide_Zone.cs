using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Zone : MonoBehaviour
{
    public Joueur joueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Joueur")
        {
            other.gameObject.layer = 8;
            joueur.GetComponent<Joueur>().playerAnimator.SetBool("IsHidden", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Joueur")
        {
            other.gameObject.layer = 10;
            joueur.GetComponent<Joueur>().playerAnimator.SetBool("IsHidden", false);
        }
    }
}
