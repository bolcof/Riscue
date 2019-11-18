using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    public GameObject PalmTree;
    private GameObject Riscue;

    public int tmpAcornNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        Riscue = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(tmpAcornNum >= 1)
            {
                becomePlamTree();
            }
            else
            {
                killRiscue();
            }
        }
    }

    public void becomePlamTree()
    {
        Instantiate(PalmTree);
        Destroy(this.gameObject);
    }

    public void killRiscue() {
        Destroy(Riscue);
    }
}
