using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Class for data loader for the Score Scene.
/// </summary>
public class DataLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData score = DataManager.LoadData();

        if (score != null || score.GetScores != default)
        {
            playerScoreText.text = score.GetScores.ToString();
        }
        else
        {
            playerScoreText.text = "";
        }
    }
}
