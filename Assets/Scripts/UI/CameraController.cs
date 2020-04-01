using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //player variable assigned to calling PlayerController script 
    public PlayerController thePlayer; 

    //store Z position of Player in world 
    private Vector3 lastPlayerPosition;  

    //move camera by certain amount as player is moving 
    private float distanceToMove;

    private GameState Gstate;
    
    void Start()
    {
        //method of how to find PlayerController component in hierarchy
        thePlayer = FindObjectOfType<PlayerController>();

        //last player position is position of where player is in that moment in time
        //grab xyz values of player (via playercontroller) and set them to lastplayerposition vector variable
        lastPlayerPosition = thePlayer.transform.position;

        Gstate = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gstate.status == GameState.State.Playing)
        {
            //difference between player position last time and it's current position 
            distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

            //position of camera is set to new x position value listed up above^ 
            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
            //we are solely adjusting x value of camera position (horizontally) not it's y or z values
            //this is important for feel of following character 

            //last player position is position of where player is in that moment in time
            //grab xyz values of player (via playercontroller) and set them to lastplayerposition vector variable
            lastPlayerPosition = thePlayer.transform.position;
        }
    }
}
