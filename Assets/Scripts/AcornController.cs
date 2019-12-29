using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D acornRigidbody;
    void Start()
    {
        acornRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //grab speed of acorn and set to new x value moveSpeed and same y value speed
        acornRigidbody.velocity = new Vector2(moveSpeed, acornRigidbody.velocity.y);
    }
}
