using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public float timeRimit = 60.0f;
    public int acorns = 0;
    public int palms = 0;
    public State status = State.Playing;

    public GameObject resultPanel;
    public Text timeText;

    public enum State
    {
        Playing,
        Pause,
        Result
    };

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = timeRimit.ToString("f1");
    }

    // Update is called once per frame
    void Update()
    {
        if (status == State.Playing)
        {
            timeRimit -= Time.deltaTime;
            timeText.text = timeRimit.ToString("f1");
        }
        else if(status == State.Result)
        {
            resultPanel.SetActive(true);
        }

        if (timeRimit <= 0.0f)
        {
            timeRimit = 0.0f;
            status = State.Result;
        }
    }
}
