using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    private Bird bird;
    public GameObject getReady, gameOver;
    private int scoreCount;
    public Text scoreCountText, highscoreText, scoreBoardText;

    void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
        PlayerPrefs.SetInt("scoreCount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.HasStarted)
        {
            getReady.SetActive(false);
        }
        if(bird.HasDied)
        {
            setNewHighScore(scoreCount);
            gameOver.SetActive(true);
            scoreCount = PlayerPrefs.GetInt("scoreCount", 0);
            scoreBoardText.text = "Score : " + scoreCount.ToString();
            highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void setNewHighScore(int score1)
    {
        if(score1 > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score1);

    }
}
