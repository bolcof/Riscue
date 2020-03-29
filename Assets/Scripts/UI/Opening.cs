using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public float timer;
    public Button playButton;
    //public GameObject difSelecter;

    // Start is called before the first frame update
    void Start()
    {
        //timer = 0.0f;
        playButton.enabled = true;
        //difSelecter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= 3.6f)
        {
            playButton.enabled = true;
        }*/
    }

    public void ClickPlay() {
        //SceneManager.LoadScene("Prototype4");
        playButton.enabled = false;
        //difSelecter.SetActive(true);
    }

    /*public void ClickStage1() {
        SceneManager.LoadScene("stage1");
    }

    public void ClickStage2()
    {
        SceneManager.LoadScene("stage2");
    }*/
}
