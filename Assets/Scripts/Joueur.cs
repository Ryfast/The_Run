using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public GameManager gameManager;

    public Animator playerAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager =(GameManager)FindObjectOfType(typeof(GameManager));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killer")
        {
            print("Game Over");
            gameManager.gameOver = true;

            gameManager.gameOverPanel.gameObject.SetActive(true);
        }
    }
}
