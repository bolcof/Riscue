using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelBehaviour : MonoBehaviour
{
    public GameObject targetPalmTree;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.28f;
    }

    // Update is called once per frame
    void Update()
    {
        float difX = this.gameObject.transform.position.x - targetPalmTree.transform.position.x;

        if (Mathf.Abs(difX) >= 0.3f)
        {
            if (difX < 0)
            {
                this.transform.Translate(speed, 0, 0);
            }
            else
            {
                this.transform.Translate(-speed, 0, 0);
            }

        }
        else if (this.gameObject.transform.position.y < -4.0f+(targetPalmTree.transform.localScale.y*9.0f))
        {
            this.transform.Translate(0, speed, 0);
        }
    }
}
