using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool pause;

    public GameObject Joueur;

    public Canvas gameOverPanel;
    public Canvas pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);

        gameOver = false;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pausePanel.gameObject.SetActive(true);
            pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            pausePanel.gameObject.SetActive(false);
            pause = false;
        }
    }

    public void Quitter()
    {
        print("EFijnzsijfnze");
        Application.Quit();
    }

    public void Rejouer()
    {
        print("QESOIFHGZREOIFJeadfophnez");
        SceneManager.LoadScene("Blockout V2");
    }
}
