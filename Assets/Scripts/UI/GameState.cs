using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameState : MonoBehaviour
{
    public float timeLimit = 30.0f;

    [SerializeField]
    public int acornScore;

    [SerializeField]
    public int palmScore;

    [SerializeField]
    public int risuScore;

    public State status = State.Playing;

    public GameObject resultPanel;
    public Text timeText;

    [SerializeField]
    private Text acornScoreText;
    [SerializeField]
    private Text palmScoreText;

    [SerializeField]
    private GameObject waterLevel;

    [SerializeField]
    private float waterLevelBottom;

    public float waterLevelTop = -1.0f;

    [SerializeField]
    private float time;

    public GameObject[] SquirrelObjs = new GameObject[9];

    public enum State
    {
        Playing,
        Pause,
        Result
    };

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("TimerScore").GetComponent<Text>();
        acornScoreText = GameObject.Find("AcornScore").GetComponent<Text>();
        palmScoreText = GameObject.Find("PalmScore").GetComponent<Text>();
        resultPanel = GameObject.Find("ResultPanel");

        timeText.text = timeLimit.ToString("f1");
        time = timeLimit;
        waterLevel = GameObject.Find("water");
        Debug.Log(waterLevel.transform.position.y);
        waterLevelBottom = waterLevel.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        runTimer();

        waterLevelRise();
    }

    public void incrementAcornScore(int score) {
        acornScoreText.text = "x" + ++acornScore;
    }

    public void incrementPalmScore(int score) {
        palmScoreText.text = "x" + ++palmScore;
    }

    private void runTimer() {
        if (status == State.Playing)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("f1");
        }
        else if(status == State.Result)
        {
            //リザルト
            //GameObject.Find("Main Camera").GetComponent<Animator>().SetBool("GoResult", true);
            //GameObject.Find("Player").GetComponent<Animator>().SetBool("GoResult", true);
        }

        if (time <= 0.0f && status != State.Result)
        {
            time = 0.0f;
            GoResult();
            status = State.Result;
        }
    }

    private void waterLevelRise(){
        float newY = waterLevelTop - ((Math.Abs(waterLevelBottom-waterLevelTop) * time / timeLimit ));
        //Debug.Log("waterLevelTop" + waterLevelTop.ToString() + "newY=" + newY.ToString());
        //Debug.Log("time=" + time.ToString() + " timeLimit=" + timeLimit.ToString());
        waterLevel.transform.position = new Vector3(waterLevel.transform.position.x, newY, waterLevel.transform.position.z);
    }


    private void callSquirrel(int num)
    {
        for (int i = 0; i < num; i++)
        {
            float seed = UnityEngine.Random.Range(0.0f, 1.0f);
            int plmi;
            if (seed < 0.5f) { plmi = -1; }
            else { plmi = 1; }

            float posX = GameObject.Find("Main Camera").transform.position.x + UnityEngine.Random.Range(9.0f, 11.0f) * plmi;
            GameObject SqlObj = Instantiate(SquirrelObjs[UnityEngine.Random.Range(0,10)], new Vector3(posX, this.gameObject.transform.position.y, -5.0f), Quaternion.identity);
            if (plmi == -1)
            {
                SqlObj.GetComponent<SquirrelBehaviour>().flip = true;
            }
            SqlObj.GetComponent<SquirrelBehaviour>().targetPalmTree = this.gameObject;
        }
    }

    public void GoResult()
    {
        Debug.Log("001");
        Invoke("ResultAppear", 6.0f);
    }

    public void ResultAppear()
    {
        Debug.Log("002");
        resultPanel.GetComponent<Animator>().SetBool("GoResult", true);
    }
}