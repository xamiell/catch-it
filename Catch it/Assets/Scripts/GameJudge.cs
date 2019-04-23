using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameJudge : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI playerOpportunityText;
    [SerializeField] ScenesManager customSceneManager;

    private int _playerScore;
    public static int ACTUAL_SCORE = default;

    public int GetPlayerScore
    {
        get => _playerScore;
    }
    
    private int _playerOpportunities;
    private int ACTUAL_BEST_SCORE;

    private const int POINT_PER_ITEM = 100;
    private const int MAX_OPPORTUNITY = 3;
    private const string BEST_SCORE_MSG = "BEST SCORE:";

    private void Awake()
    {
        ACTUAL_BEST_SCORE = DataManager.LoadData().GetScores;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_playerScore = int.Parse(playerScoreText.text, System.Globalization.NumberStyles.Integer);
        _playerScore = default;

        playerScoreText.text = _playerScore.ToString();
        bestScoreText.text = $"{ BEST_SCORE_MSG } { ACTUAL_BEST_SCORE }";

        _playerOpportunities = MAX_OPPORTUNITY;
        playerOpportunityText.text = $"x{ _playerOpportunities }";
    }
    
    void Update()
    {
        if ( _playerOpportunities < 1 )
        {
            SaveCurrentBestScore();
            customSceneManager.OnGameOver();
        }

        if ( _playerScore > ACTUAL_BEST_SCORE )
        {
            bestScoreText.text = $"{ BEST_SCORE_MSG } YOU";
        }
    }

    private void SaveCurrentBestScore()
    {
        if ( this.GetPlayerScore > ACTUAL_BEST_SCORE )
        {
            DataManager.SaveData( this.GetPlayerScore );
        }

        ACTUAL_SCORE = _playerScore;
    }

    public void AddScore()
    {
        playerScoreText.text = ( _playerScore += POINT_PER_ITEM ).ToString();
    }

    public void DisminOpportunity()
    {
        playerOpportunityText.text = $"x{ ( _playerOpportunities -= 1 ).ToString() }";
    }
}
