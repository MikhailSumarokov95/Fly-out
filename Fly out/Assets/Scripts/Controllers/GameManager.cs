using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onStartMenuGame;
    public UnityEvent onStartGame;
    public UnityEvent onPauseGame;
    public UnityEvent onResumeGame;
    public UnityEvent onRoundOver;
    public UnityEvent onNextRound;
    public UnityEvent onGameOver;
    public UnityEvent onRestartGame;

    private void Start() => StartMenuGame();

    public void StartMenuGame() => onStartMenuGame?.Invoke();

    public void StartGame() => onStartGame?.Invoke();

    public void PauseGame()
    {
        onPauseGame?.Invoke();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        onResumeGame?.Invoke();
        Time.timeScale = 1;
    }

    public void RoundOver() => onRoundOver?.Invoke();

    public void NextRound() => onNextRound.Invoke();

    public void GameOver() => onGameOver?.Invoke();

    public void RestartGame() => onRestartGame?.Invoke();
}
