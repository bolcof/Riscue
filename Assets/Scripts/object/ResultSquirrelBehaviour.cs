using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSquirrelBehaviour : MonoBehaviour
{
    public GameObject targetPalmTree;
    private float speed;
    public bool flip, up;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.25f, 0.285f);
        this.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f) * Random.Range(0.67f, 0.85f);
        if (flip) { this.gameObject.GetComponent<SpriteRenderer>().flipX = true; }
        up = false;
        targetPalmTree = GameObject.Find("BIGPALM TREE");
    }

    // Update is called once per frame
    void Update()
    {
        float difX = this.gameObject.transform.position.x - targetPalmTree.transform.position.x;

        if (Mathf.Abs(difX) >= 0.3f && !up)
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
        else if (this.gameObject.transform.position.y < -4.0f + (targetPalmTree.transform.localScale.y * 9.0f))
        {
            up = true;

            if (flip)
            {
                this.transform.Translate(speed, 0, 0);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            }
            else
            {
                this.transform.Translate(-speed, 0, 0);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            }
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Saved", true);
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
