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

    public enum State
    {
        Playing,
        Pause,
        Result
    };

    // Start is called before the first frame update
    void Start()
    {
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
            resultPanel.SetActive(true);
        }

        if (time <= 0.0f)
        {
            time = 0.0f;
            status = State.Result;
        }
    }

    private void waterLevelRise(){
        float newY = waterLevelTop - ((Math.Abs(waterLevelBottom-waterLevelTop) * time / timeLimit ));
        Debug.Log("waterLevelTop" + waterLevelTop.ToString() + "newY=" + newY.ToString());
        Debug.Log("time=" + time.ToString() + " timeLimit=" + timeLimit.ToString());
        waterLevel.transform.position = new Vector3(waterLevel.transform.position.x, newY, waterLevel.transform.position.z);
    }



    // void OnGUI (){
    //     GUI.Box(new Rect(Screen.width/2 + sizeX/2, offsetY, sizeX, sizeY), " " + currentScore); 

    // }
}
