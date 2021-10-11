using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Creates the logic for the main menu, by Josiah Holcom
/// </summary>
public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

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
        /*if(PlayerPrefs.HasKey("Highscore")) 
        {//^^^ maybe use PlayerPrefs? That's what I'm thinking of but i'm not sure
             PlayerPrefs.SetInt("Highscore", 0);
        }*/
    }
}
