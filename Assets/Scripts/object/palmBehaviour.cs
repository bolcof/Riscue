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
           
            SR.enabled = false;
            isGrowing = true;

            gameState.incrementPalmScore(1);
        
        }
    }
}
