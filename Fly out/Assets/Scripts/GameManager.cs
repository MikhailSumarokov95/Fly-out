using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onStartMenuGame;
    public UnityEvent onStartGame;
    public UnityEvent onPauseGame;
    public UnityEvent onGameOver;
    public UnityEvent onRestartGame;

    private void Start() => StartMenuGame();

    public void StartMenuGame() => onStartMenuGame?.Invoke();

    public void StartGame() => onStartGame?.Invoke();

    public void PauseGame() => onPauseGame?.Invoke();

    public void GameOver() => onGameOver?.Invoke();

    public void RestartGame() => onRestartGame?.Invoke();
}
