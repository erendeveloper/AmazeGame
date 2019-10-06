using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //This script manages game components


    public GameObject planesHolder;          //Planes Gameobject
    public GameObject gameUIDesignerHolder;  //GameDesignUI Gameobject
    private int numberOfPlanes;              //total number of planes on the floor
    private int numberOfPaintedPlanes = 0;   //number of painted planes


    // Start is called before the first frame update
    void Start()
    {
        getNumberOfPlanes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getNumberOfPlanes()
    {
        numberOfPlanes = planesHolder.transform.childCount;
    }
    public void increaseNumberOfPaintedPlanes()
    {
        numberOfPaintedPlanes++;
        if(numberOfPaintedPlanes == numberOfPlanes)
        {
            gameOver();
        }
    }
    void gameOver()
    {
        gameUIDesignerHolder.GetComponent<GameUIDesigner>().openLevelPassedPanel();
    }
}
