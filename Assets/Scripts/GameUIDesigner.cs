using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIDesigner : MonoBehaviour
{
    //This manages all UI elements

    public GameObject pausePanel;           //Pause Panel Gameobject
    public GameObject levelPassedPanel;     //Level Passed Panel GameObject

    private Transform Ball;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="Game")
        Ball = GameObject.Find("ball").transform;  //Assigns ball gameobject to access 'MoveBall' script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openLevelPassedPanel() //opens Level Passed Panel
    {
        levelPassedPanel.SetActive(true);
    }
    public void pauseButton()      
    {
        pausePanel.SetActive(true);   //opens Pause Panel
        Ball.GetComponent<MoveBall>().turnOffGamePlay();  //pause the game
    }
    public void resumeButton() {
        pausePanel.SetActive(false);   //closes Pause Panel
        Ball.GetComponent<MoveBall>().turnOnGamePlay();  //resume the game
    } 
    public void startButton() //Opens 'Game' scene
    {
        SceneManager.LoadScene("Game");
    }

}
