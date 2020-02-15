using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    public int layerNUM;
    public GameObject[] layer;
    public float[] layerImageWidth;
    private int[] addedLayerNum = new int[6];
    public float[] layerMoveScale;
    public PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < layerNUM; i++)
        {
            addedLayerNum[i] = 0;
        }

        for(int i =0; i < 10; i++)
        {
            addBackground();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            addBackground();
        }
        for(int i = 0; i < layerNUM; i++)
        {
            if (!PC.stopped)
            {
                layer[i].transform.Translate(layerMoveScale[i] * PC.moveSpeed / 4.0f, 0, 0);
            }
        }
    }

    void addBackground() {
        for (int i = 0; i < layerNUM; i++)
        {
            GameObject tmpObj;
            if (layerMoveScale[i] > 0)
            {
                tmpObj = Instantiate(layer[i],
                new Vector3(layer[i].transform.position.x + layerImageWidth[i] * (addedLayerNum[i] + 1),
                    layer[i].transform.position.y,
                    layer[i].transform.position.z),
                Quaternion.identity,
                this.transform);
            }
            else
            {
                tmpObj = Instantiate(layer[i],
                new Vector3(layer[i].transform.position.x - layerImageWidth[i] * (addedLayerNum[i] + 1),
                    layer[i].transform.position.y,
                    layer[i].transform.position.z),
                Quaternion.identity,
                this.transform);
            }
            tmpObj.transform.parent = layer[i].transform;
            addedLayerNum[i]++;
        }
    }
}
