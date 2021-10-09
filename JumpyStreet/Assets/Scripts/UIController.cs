using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //text goes here
    [SerializeField] Text pointsText;
    [SerializeField] Text highscoreText;

    public int points = 0;
    int highscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = points.ToString();
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
}
