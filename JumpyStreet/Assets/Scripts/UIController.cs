using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //text goes here
    [SerializeField] GameObject overPanel;
    [SerializeField] Text pointsText;
    [SerializeField] Text overPointsText;
    [SerializeField] Text highscoreText;

    public int points = 0;
    public int highscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pointsText.text = points.ToString();
        overPanel.SetActive(false);

        if(PlayerPrefs.HasKey("Highscore")) 
        {//^^^ maybe use PlayerPrefs? That's what I'm thinking of but i'm not sure
            highscore = PlayerPrefs.GetInt("Highscore");
        }
    }

    public void ScorePoints()
    {
        points++;
        pointsText.text = points.ToString();
        if (points >= highscore)
        {
            highscore = points;
        }
    }

    public void DisplayGameOver()
    {
        Time.timeScale = 0.25f;
        overPanel.SetActive(true);
        overPointsText.text = ("Your score: " + points);
        highscoreText.text = ("Highscore: " + highscore);
        PlayerPrefs.SetInt("Highscore", highscore); //<-- playerprefs???
    }

    public void OnClickResetButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickReturnButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickQuitButton()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
