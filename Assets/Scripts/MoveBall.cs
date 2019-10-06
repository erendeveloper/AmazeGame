using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    //this script moves the ball

    Vector2 firstSwipePosition;  //swipe input position for starting point
    float swipeDistance = 100f;  //swipe thresholder

    float ballSpeed = 5f;  //moving speed

    bool move = false;     //moving
    bool gamePlay = true;  //game is playing, later paused

    //available ways for the ball
    bool upWay = false;
    bool downWay = false;
    bool rightWay = false;
    bool leftWay = false;

    //target positions via available ways
    float upPosition;
    float downPosition;
    float rightPosition;
    float leftPosition;

    //target position to move
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlay == true) //when paused game not plays
        {
            if (!move) 
            {

                if (Input.GetMouseButtonDown(0)) //sets first swipe position
                {
                    checkWays();
                    firstSwipePosition = Input.mousePosition; //Debug.Log("first:" + firstSwipePosition.ToString());
                }
                if (Input.GetMouseButton(0)) //sets last swipe position
                {
                    swipe();
                }
            }

            if (move == true) //ball moves to target position
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * ballSpeed);

                if (Vector3.Distance(transform.position, targetPosition) < 0.001f) //stable latest position
                {
                    transform.position = targetPosition;
                    move = false;
                    checkWays();
                }
            }
        }
        
         
    }

    void swipe() // swipe to get way
    {
        Vector2 lastSwipePosition = Input.mousePosition;
        float distanceX = lastSwipePosition.x - firstSwipePosition.x;
        float distanceY = lastSwipePosition.y - firstSwipePosition.y;

        //gets the way if it gets swipeSistance
        if ((upWay==true) && (distanceY >= swipeDistance)) //up way
        {
            targetPosition = new Vector3(transform.position.x,transform.position.y,upPosition);
            firstSwipePosition = lastSwipePosition;
            move = true;
        }
        else if((downWay == true) && (distanceY <= -swipeDistance)) //down way
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y, downPosition);
            firstSwipePosition = lastSwipePosition;
            move = true;
        }
        else if ((rightWay == true) && (distanceX >= swipeDistance)) //right way
        {
            targetPosition = new Vector3(rightPosition, transform.position.y, transform.position.z);
            firstSwipePosition = lastSwipePosition;
            move = true;
        }
        else if ((leftWay == true) && (distanceX <= -swipeDistance)) //left way
        {
            targetPosition = new Vector3(leftPosition, transform.position.y, transform.position.z);
            firstSwipePosition = lastSwipePosition;
            move = true;
        }
        
    }

    //checks all the available ways via sending rays to the walls
    void checkWays()
    {
        RaycastHit hit;

        //up way
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit))
        {
            upWay = true;
            upPosition = hit.transform.position.z - 1;
        }
        else
        {
            upWay = false;
        }
        //down way
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), out hit))
        {
            downWay = true;
            downPosition = hit.transform.position.z + 1;
        }
        else
        {
            downWay = false;
        }
        //right way
        if (Physics.Raycast(transform.position, new Vector3(1, 0, 0), out hit))
        {
            rightWay = true;
            rightPosition = hit.transform.position.x - 1;
        }
        else
        {
            rightWay = false;
        }
        //left way
        if (Physics.Raycast(transform.position, new Vector3(-1, 0, 0), out hit))
        {
            leftWay = true;
            leftPosition = hit.transform.position.x + 1;
        }
        else
        {
            leftWay = false;
        }
    }
    public void turnOnGamePlay()  //enable gameplay
    {
        gamePlay = true;
    }
    public void turnOffGamePlay() //disable gameplay to pause
    {
        gamePlay = false;
    }
}
