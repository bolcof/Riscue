using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palmBehaviour : MonoBehaviour
{
    public int GrowthLevel = 0;
    public int GrowthLevelMax = 4;
    public Sprite[] palmImage = new Sprite[5];
    public float[] palmScale = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GrowthLevel >= GrowthLevelMax) { GrowthLevel = GrowthLevelMax; }
        else if(GrowthLevel <= 0) { GrowthLevel = 0; }
        this.GetComponent<SpriteRenderer>().sprite = palmImage[GrowthLevel];
        this.transform.localScale = new Vector3(palmScale[GrowthLevel], palmScale[GrowthLevel], palmScale[GrowthLevel]);
    }
}
