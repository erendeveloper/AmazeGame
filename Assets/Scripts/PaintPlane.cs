using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlane : MonoBehaviour
{
    //while ball moves over the planes, they will be painted

    private Transform MainScriptHolder; //MainScript Gamebject

    // Start is called before the first frame update
    void Start()
    {
        MainScriptHolder = GameObject.Find("MainScript Holder").transform; //to access MainScript.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Plane>().paint()==true) //checks if the plane already painted
           MainScriptHolder.GetComponent<MainScript>().increaseNumberOfPaintedPlanes();  //increase the number of painted planes
    }
}
