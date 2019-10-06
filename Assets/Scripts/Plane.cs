using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    //this script paints the plane

    bool painted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool paint() //paint the plane, return true if the first time painted
    {
        if (!painted)
        {
            this.transform.GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 255); //paint to green
            painted = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
