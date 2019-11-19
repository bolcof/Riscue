using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform; 
    public Transform generationPoint;
    public float distanceBetween; 

    private float platformWidth;  

    //Randomization distanceBetween variables 
    public float distanceBetweenMin;
    public float distanceBetweenMax; 
    
    
    void Start()
    {
        //set length of platform equal to our float 
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; 
    }
 
    
    void Update()
    {
        //is our platformgenerator less than our platformgeneration point? (find difference)
        //if it is; create new platform where platformgeneration point is in scene 

        //if x position of platform obj right now is less than generation point 
        if(transform.position.x < generationPoint.position.x){

            //randomize distance between platforms 
            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

            //move transform ahead -> move x value ahead by our platformwidth and distanceBetween, then keep y and z values the same
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //create new platform 
            Instantiate (thePlatform, transform.position, transform.rotation);
        }
    }
}
