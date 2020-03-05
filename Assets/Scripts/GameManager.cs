using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    //Purpose... 
    //  + Loading Scenes
    //  + Managing UI such as text and buttons
    //  - Keeping track UI variables such as score
    //
    //Script By Thomas Joyce

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public int score;

    //Loads scene corresponding to that number
    //0 - "_MainMenu"
    //1 - "_MainScene" (GameLevel)
    public void loadScene(int sceneNum){
        SceneManager.LoadScene(sceneNum);
    }

    //loads next scene in build index 
    public void nextScene(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    //quits game
    public void quitGame(){
        Application.Quit();
    }

    //sets score text UI
    public void setScoreUI(int scoreNum){
        score += scoreNum;
        //scoreText.text = "Score: " + score";
    }
}
