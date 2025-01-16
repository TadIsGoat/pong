using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> rockets = new List<GameObject>();

    public bool gameOn = false;
    public bool gamePaused = false;

    public int playerScore = 0;
    public int aiScore = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    public void StartGame()
    {
        if (!gameOn)
        {
            gameOn = true;
            ball.GetComponent<BallScript>().Launch();
            UpdateScore();
        }
    }

    public void StopGame(bool scored) //true if player scored, false if ai scored
    {
        ball.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        
        foreach (var rocket in rockets)
        {
            rocket.GetComponent<RocketScript>().transform.position = rocket.GetComponent<RocketScript>().spawnPos;
        }

        gameOn = false;

        if (scored)
        {
            playerScore++;
        }
        else if (!scored)
        {
            aiScore++;
        }

        UpdateScore();
    }

    public void ResetGame()
    {
        playerScore = 0;
        playerScore = 0;
        gameOn = false;
        UpdateScore();
    }

    public void Pause()
    {
        if (!gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0;
        }
        else if (gamePaused)
        {
            gamePaused = false;
            Time.timeScale = 1;
        }
    }

    public TextMeshProUGUI ScoreText
    {
        get { return scoreText; }
        set { scoreText.text = ScoreTextString; }
    }

    public string ScoreTextString
    {
        get { return $"{playerScore} : {aiScore}"; }
    }

    private void UpdateScore()
    {
        scoreText.text = ScoreTextString;
    }
}
