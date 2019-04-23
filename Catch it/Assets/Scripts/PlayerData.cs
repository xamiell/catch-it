using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int _scores;

    public int GetScores
    {
        get
        {
            return _scores;
        }
    }

    public PlayerData(int score)
    {
        _scores = new int();
        _scores = score;
    }
}
