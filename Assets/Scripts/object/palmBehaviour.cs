using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palmBehaviour : MonoBehaviour
{
    public float growSpeed;
    public float palmScale;
    public bool isGrowing;
    public Animator Anim;
    public PlayerController PC;
    public SpriteRenderer SR;
    public GameObject SquirrelObj;

    private GameState gameState;

    public int successValue = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        isGrowing = false;
        this.transform.localScale = new Vector3(1, 1, 1) * palmScale * Random.Range(0.8f, 1.4f);
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Anim.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acorn")) {

            this.tag = ("PalmTree");
            SR.enabled = false;
            isGrowing = true;

            int tmp = Random.Range(1, 4);
            callSquirrel(tmp);
            gameState.risuScore += tmp;
            //callSquirrel(1);

            gameState.incrementPalmScore(1);
        
        }
    }

    private void callSquirrel(int num)
    {
        for(int i = 0; i < num; i++)
        {
            float seed = Random.Range(0.0f,1.0f);
            int plmi;
            if(seed < 0.5f) { plmi = -1; }
            else { plmi = 1; }
        
            float posX = GameObject.Find("Main Camera").transform.position.x + Random.Range(9.0f, 11.0f) * plmi;
            GameObject SqlObj = Instantiate(SquirrelObj, new Vector3(posX, this.gameObject.transform.position.y, -5.0f), Quaternion.identity);
            if(plmi == -1) {
                SqlObj.GetComponent<SquirrelBehaviour>().flip = true;
            }
            SqlObj.GetComponent<SquirrelBehaviour>().targetPalmTree = this.gameObject;
        }
    }
}
