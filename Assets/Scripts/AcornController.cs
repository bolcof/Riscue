using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Acorn")){
            Destroy(other.gameObject); 
        }
    }
}
