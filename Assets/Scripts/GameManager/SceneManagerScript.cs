using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class SceneManagerScript : MonoBehaviour
{

    public Animator transition; 

    public float transitiontime = 1f; 

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextStage();
        }

    }
    public void LoadNextStage()
    {
        StartCoroutine(LoadStage(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadStage(int stageIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime); 

        //無理やり
        if(stageIndex == 6) { stageIndex = 5; }
        SceneManager.LoadScene(stageIndex); 

    }

    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
