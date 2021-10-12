using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Creates the logic for the main menu, by Josiah Holcom
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    //UIController ui;

    // Start is called before the first frame update
    void Start()
    {
        //ui = FindObjectOfType<UIController>();

        if (PlayerPrefs.HasKey("Highscore"))
        {//^^^ maybe use PlayerPrefs? That's what I'm thinking of but i'm not sure
            highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();

        }
    }

    public void OnPlayButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ResetHighscore()
    {
        if(PlayerPrefs.HasKey("Highscore")) 
        {
             PlayerPrefs.SetInt("Highscore", 0);
             highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
