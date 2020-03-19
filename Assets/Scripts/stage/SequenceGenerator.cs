using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator : MonoBehaviour
{
    public int level;
    public GameObject[] sequence = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        if(level == 1){
            for (int i = 1; i < sequence.Length+1; i++) {
                string fileNum = i.ToString("D2");
                sequence[i-1] = (GameObject)Resources.Load("Prefabs/Sequence/easy/Sequence_e" + fileNum);
            }
        }else{
            for (int i = 1; i < sequence.Length+1; i++) {
                string fileNum = i.ToString("D2");
                sequence[i-1] = (GameObject)Resources.Load("Prefabs/Sequence/normal/Sequence_n" + fileNum);
            }
        }
        for (int j = 0; j < 30; j++)
        {
            Vector3 pos;
            pos = new Vector3(20.0f * (j + 1), 0.0f, 0.0f);
            Instantiate(sequence[Random.Range(0, 8)], pos, Quaternion.identity, this.gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
