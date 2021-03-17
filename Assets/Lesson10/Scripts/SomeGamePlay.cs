using System;
using Lesson10.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SomeGamePlay : MonoBehaviour
{
    public Text _txtScore;
    public Button _btnAddOne;
    public Button _btnLaunchFromPool;

    public GameObject prefabRocket;
    public int BallPerClick = 1;

    private void Awake()
    {
        _btnAddOne?.onClick.AddListener(SomeLogic);
        _btnLaunchFromPool?.onClick.AddListener(OnLauchFromPoolClicked);
    }

    private void OnLauchFromPoolClicked()
    {
        SpawnBalls(true);
    }

    private void SomeLogic()
    {
        SpawnBalls(false);
    }

    private void SpawnBalls(bool usePool)
    {
        for (var i = 0; i < BallPerClick; i++)
        {
            ScoreTracking.Instance.IncreaseScoreBy(1);

            _txtScore.text = ScoreTracking.Instance.GetScore() + "$";

            GameObject newBall;
            
            if (!usePool)
            {
                newBall = Instantiate(prefabRocket, Vector3.zero, Quaternion.identity);
            }
            else
            {
                newBall = SimplePool.Instance.Get();
            }

            newBall.transform.position = Vector3.zero;
            newBall.GetComponent<Ball>().Fly(45);
        }
    }
}