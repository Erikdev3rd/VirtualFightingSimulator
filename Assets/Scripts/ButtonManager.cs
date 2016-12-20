using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    newGame newGameScript;

    public void loadSceneBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void newGameBtn(string newGameLevel)
    {
        newGameScript = GameObject.Find("HNewGame").GetComponent<newGame>();
        newGameScript.startNewHordeGame = true;
        SceneManager.LoadScene(newGameLevel);
    }

    public void continueGameBtn(string continueGameLevel)
    {
        newGameScript = GameObject.Find("HNewGame").GetComponent<newGame>();
        newGameScript.startNewHordeGame = false;
        SceneManager.LoadScene(continueGameLevel);
    }

    public void exitGameBtn()
    {
        Application.Quit();
    }

    public void newFighterGameBtn(string newGameLevel)
    {
        newGameScript = GameObject.Find("FNewGame").GetComponent<newGame>();
        newGameScript.startNewFighterGame = true;
        SceneManager.LoadScene(newGameLevel);
    }

    public void continueFighterGameBtn(string continueGameLevel)
    {
        newGameScript = GameObject.Find("FNewGame").GetComponent<newGame>();
        newGameScript.startNewFighterGame = false;
        SceneManager.LoadScene(continueGameLevel);
    }
}
