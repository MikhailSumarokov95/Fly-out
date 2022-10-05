using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public UnityEvent onCountedScore;
    [SerializeField] private TMP_Text scoreRoundText;
    [SerializeField] private TMP_Text scoreGameText;
    [SerializeField] private GameObject LeaderBoard;
    private int _roundScore = -1;
    private bool _isCountScore;
    private float _timerDelayAfterCounting;
    private LeaderBoard _leaderBoard;
    readonly float _delayAfterCounting = 1f;

    private void Update()
    {
        if (_isCountScore) _timerDelayAfterCounting += Time.deltaTime;
        if (_timerDelayAfterCounting > _delayAfterCounting)
        {
            _timerDelayAfterCounting = 0;
            _isCountScore = false;
            onCountedScore?.Invoke();
            LeaderBoard.SetActive(true);
            if (_leaderBoard == null) _leaderBoard = FindObjectOfType<LeaderBoard>();
            _leaderBoard.StartLeaderBoard(_roundScore);
        }
    }

    public void CountScore(int score)
    {
        if (score > _roundScore)
        {
            _roundScore = score;
            scoreRoundText.text = _roundScore.ToString();
            _isCountScore = true;
        }
    }

    public void NextRound()
    {
        scoreGameText.text = (int.Parse(scoreGameText.text) + _roundScore).ToString();
        _roundScore = -1;
        scoreRoundText.text = "0";
        _timerDelayAfterCounting = 0;
        _isCountScore = false;
        LeaderBoard.SetActive(false);
    }

    public void NextGame()
    {
        _roundScore = -1;
        scoreRoundText.text = "0";
        scoreGameText.text = "0";
        _timerDelayAfterCounting = 0;
        _isCountScore = false;
        LeaderBoard.SetActive(false);
    }
}
