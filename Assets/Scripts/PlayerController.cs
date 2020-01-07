﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioAcornCollect; 

    public GameObject theAcorn; 

    public float moveSpeed;
    public float jumpForce;

    public float movedRate;
    private float exPos, nowPos;

    private Rigidbody2D myRigidbody;

    public bool grounded, stopped;

    public bool spit; 
    public LayerMask whatIsGround;
    public int AcornNum;

    private Collider2D myCollider; 

    private Animator myAnimator; 

    //public bool acornnum;

    void Start()
    {
        //grab Rigidbody2D component from Player 
        myRigidbody = GetComponent<Rigidbody2D>();

        //grab Box Collider component from Player
        myCollider = GetComponent<Collider2D>(); 

        //grab Animator component from Player 
        myAnimator = GetComponent<Animator>();

        myAnimator.SetInteger("AcornNum", AcornNum);

        exPos = this.gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (myAnimator.GetBool("Spit")){
            myAnimator.SetBool("Spit", false);
        }
        //return true or false if collider is touching another collider on different layer
        //aka is player collider touching ground collider (different layers)  
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //spit = 

        //grab speed of Player and set to new x value moveSpeed and same y value speed
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //if you press up arrow, W or hold mouse down 
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
        {
            if (grounded) //is true 
            {
                //set Player's speed to a new jumping value 
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        exPos = nowPos;
        nowPos = this.transform.position.x;
        if (nowPos - exPos < 0.05f) { stopped = true; }
        else { stopped = false; }

        if(Input.GetKeyDown(KeyCode.Space) && AcornNum > 0){
          myAnimator.SetBool ("Spit", true);
          Debug.Log("testing spit"); 

          InstantiateAcornSpit(); 
          Debug.Log("am I instantiating acorn?"); 

        }

        //grab speed value of Player and set it to Speed variable in Animator 
        myAnimator.SetFloat ("Speed", myRigidbody.velocity.x); 

        //set grounded boolean (layer checker) to Grounded boolean in Animator 
        myAnimator.SetBool ("Grounded", grounded); 

        //Restart Level 
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
   
    }

    //Collecting Acorns 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Acorn")){
            audioAcornCollect.Play(); 
            Destroy(other.gameObject);
            AcornNum++;
            myAnimator.SetInteger("AcornNum", AcornNum);
        }
    }

    private void InstantiateAcornSpit(){
        //in front of player position (x-5) instantiate acorn 
        Vector3 acornPosition = new Vector3(this.transform.position.x + 1.2f, transform.position.y+1, transform.position.z);
        //create new game object to put instantiated acorn in 
        GameObject myAcornGO = Instantiate(theAcorn, acornPosition, transform.rotation);
        //then adjust speed of that INSTANTIATED acorn rather than the prefab version
        myAcornGO.GetComponent<AcornController>().moveSpeed = 10;
        myAcornGO.GetComponent<Rigidbody2D>().gravityScale = 1; 
        AcornNum--; 
    }
}
