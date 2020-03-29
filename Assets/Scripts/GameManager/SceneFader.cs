using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Scripts Purpose: 
//animate a single number, which is the alpha channel, on our image over time. 

//use Coroutines to track timing for fading in alpha number. 

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve; 

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    //helper method to help transition between scenes 
    //easier than calling a Coroutine in Start for FadeOut. 
    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
        //IEnumerator allows us to control the amount of frames/secs we want to go down by. 
    {
        //Purpose: if fade in, we want to go from black to seeing the scene
        //animate img to having an alpha of 1 -> slowly down to 0 
        //ie. make alpha # smaller. 

        float t = 1f; //animate from 1->0 

        while (t > 0f)
        {
            //keep on animating until time value reaches 0
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, a); //input alpha value -> t is now a 

            //wait until next frame. 
            yield return 0; 
        }
        //continue loop
    }


    IEnumerator FadeOut(string scene)
    //IEnumerator allows us to control the amount of frames/secs we want to go down by. 
    {
        //Purpose: if fade in, we want to go from black to seeing the scene
        //animate img to having an alpha of 1 -> slowly down to 0 
        //ie. make alpha # smaller. 

        float t = 0f; //animate from 1->0 

        while (t < 1f)
        {
            //keep on animating until time value reaches 0
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); //input alpha value -> t is now a 

            //wait until next frame. 
            yield return 0;
        }
        //input next scene that we just specified 
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
