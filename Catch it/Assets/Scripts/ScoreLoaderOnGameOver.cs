using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoaderOnGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI bestPlayerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadScoreData();
    }

    private void LoadScoreData()
    {
        var currentScore = GameJudge.ACTUAL_SCORE.ToString();
        var bestScore = DataManager.LoadData().GetScores.ToString();

        playerScoreText.text = $"YOUR SCORE: { currentScore }";
        bestPlayerScoreText.text = $"BEST SCORE: { bestScore }";
    }
}
