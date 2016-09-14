using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public Canvas mainMenu;
    public Button playText;
    public Button quitText;
    public Canvas instructionMenu;
    public Button startText;
    public Button backText;
    public Canvas gameoverMenu;
    


    void Start()

    {
        mainMenu = mainMenu.GetComponent<Canvas>();
        playText = playText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        instructionMenu = instructionMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        backText = backText.GetComponent<Button>();
        gameoverMenu = gameoverMenu.GetComponent<Canvas>();
    }

    public void instructionLevel()
    {
        SceneManager.LoadScene("Instructions");
    }


    public void playLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void instruback()
    {
        SceneManager.LoadScene("Startmenu");
    }


    public void quitGame()
    {

        Application.Quit();

    }
}

