using System;
using UnityEngine;
using UnityEngine.UI;

public class SomeGamePlay : MonoBehaviour
{
    public Text _txtScore;
    public Button _btnAddOne;

    private void Awake()
    {
        _btnAddOne?.onClick.AddListener(OnPlayerWin);
    }

    private void OnPlayerWin()
    {
        ScoreTracking.Instance.IncreaseScoreBy(1);

        _txtScore.text = ScoreTracking.Instance.GetScore() + "$";
    }
}