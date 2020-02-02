using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public float timer;
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        playButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= 3.6f)
        {
            playButton.enabled = true;
        }
    }

    public void ClickPlay() {
        SceneManager.LoadScene("Prototype4");
    }
}
