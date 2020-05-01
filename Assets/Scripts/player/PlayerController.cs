using System.Collections;
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

    public float counter; 

    private Rigidbody2D myRigidbody;

    public bool grounded, stopped;

    public LayerMask whatIsGround;
    public int AcornNum;

    private Collider2D myCollider; 

    private Animator myAnimator;

    public GameState gameStageObj;

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

        gameStageObj = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //return true of false is player tag is touching hole tag 
   
        
        if (myAnimator.GetBool("Spit")){
            myAnimator.SetBool("Spit", false);
        }

        //return true or false if collider is touching another collider on different layer
        //aka is player collider touching ground collider (different layers)  
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //spit = 

        if (gameStageObj.status == GameState.State.Playing && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_fall"))
        {
            myRigidbody.constraints = RigidbodyConstraints2D.None;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            //grab speed of Player and set to new x value moveSpeed and same y value speed
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

            //if you press up arrow, W or hold mouse down 
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
            {
                if (grounded) //is true 
                {
                    //set Player's speed to a new jumping value 
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                }
            }


            if (Input.GetKeyDown(KeyCode.Space) && AcornNum > 0)
            {
                myAnimator.SetBool("Spit", true);
                Debug.Log("testing spit");

                InstantiateAcornSpit();
                Debug.Log("am I instantiating acorn?");
            }
        }
        else if (gameStageObj.status == GameState.State.Result)
        {
            //myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            myCollider.enabled = false;
            myRigidbody.velocity = new Vector2(moveSpeed * 2, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        exPos = nowPos;
        nowPos = this.transform.position.x;
        if (nowPos - exPos < 0.05f) { stopped = true; }
        else { stopped = false; }

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
            //Update acorn score
            gameStageObj.incrementAcornScore(1);
        }
        if(other.gameObject.CompareTag("Hole")){
            myAnimator.SetTrigger("Fallen");
            this.transform.position = other.transform.position - new Vector3(0.25f, 0.0f, 1.0f);
            Debug.Log("Am I hitting a hole?"); 
        }
    }

    private void InstantiateAcornSpit(){
        //in front of player position (x-5) instantiate acorn 
        Vector3 acornPosition = new Vector3(this.transform.position.x + 1.03f, transform.position.y+1, transform.position.z + Mathf.Sin(Mathf.PI * 2 * counter / 360));
        //create new game object to put instantiated acorn in 
        GameObject myAcornGO = Instantiate(theAcorn, acornPosition, transform.rotation);
        //then adjust speed of that INSTANTIATED acorn rather than the prefab version
        myAcornGO.GetComponent<AcornController>().moveSpeed = 13;
        myAcornGO.GetComponent<Rigidbody2D>().gravityScale = 3; 
        AcornNum--; 
    }
}
