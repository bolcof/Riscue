using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint; 

    void Start()
    {
        //find game object in hierarchy called PlatformDestructionPoint
        platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
    }

    void Update()
    {
        //if x position of platform is less than platformDestructionPoint; destroy it 
        if(transform.position.x < platformDestructionPoint.transform.position.x){
            Destroy (gameObject); 
        }
    }
}
