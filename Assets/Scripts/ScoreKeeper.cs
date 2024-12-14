using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * The ScoreKeeper Script manages the game logic and score.
 * Put this script on the Canvas game object and tag it as "ScoreKeeper"
 * Several other scripts will make use of these functions to update the score, number of balls and game state.
 * 
 * This script needs:
 * The Ball Number UI element to be tagged as "BallNumber"
 * The Score Number UI element to be tagged as "ScoreNumber"
 * 
 */
public class ScoreKeeper : MonoBehaviour
{
    float score = 0;
    Text scoreText;
    Text ballText;
    public float numberOfBalls = 3;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreNumber").GetComponent<Text>();
        ballText = GameObject.FindGameObjectWithTag("BallNumber").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        ballText.text = numberOfBalls.ToString();
    }
    //Add a number of points the the total score.
    public void addPoints(float amount)
    {
        score = score + amount;
    }

    void GameOver()
    {
        Debug.Log("GameOVER");
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    public void changeBallAmount(float amount)
    {
        numberOfBalls = numberOfBalls + amount;
        if (numberOfBalls <= 0)
        {
            GameOver();
        }
    }
}
