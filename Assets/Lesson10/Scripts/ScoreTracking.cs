using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    private static ScoreTracking _instance;

    public static ScoreTracking Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    private int _score;

    void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = new ScoreTracking();
    }

    public int GetScore()
    {
        return _score;
    }

    public void IncreaseScoreBy(int value)
    {
        if (value <= 0) return;
        
        _score += value;
    }
}
