using Oculus.Interaction.DebugTree;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameState gameState;
    public static GameController gameController;
    [SerializeField] GameObject runTrigger, vase;

    [SerializeField] TMP_Text score, highScoreText, timer;

    public int points = 0;
    private int highScore = 0;

    float time = 300f;

    void Start()
    {
        gameController = this;
        gameState = GameState.GetSeed;
    }

    private void Update()
    {
        if (gameState != GameState.EndGame)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                if (points > highScore) highScore = points;
                points = 0;
                time = 300f;
                UpdateGameState(GameState.EndGame);
            }//End Game Logic

            score.text = "Score: " + points.ToString();
            highScoreText.text ="HighScore: " + highScore.ToString();
            timer.text = "Timer: " + Mathf.Ceil(time).ToString();
        }
        
    }

    public void UpdateGameState(GameState state)
    {
        gameState = state;

        switch (gameState) 
        {
            case GameState.Watering:
                //runTrigger.SetActive(false);
                break;
            case GameState.Disposing:
                //runTrigger.SetActive(true);
                break;
            case GameState.EndGame:
                GameObject go = vase.transform.GetChild(1).gameObject;
                Destroy(go);
                UpdateGameState(GameState.GetSeed);
                break;
            default:
                break;
        }
    }

}

public enum GameState
{
    Watering,
    Planting,
    GetSeed,
    Disposing, 
    EndGame
} 
