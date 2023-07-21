using System;
using UnityEngine;
public class GameManagerEvents {
    private event Action<int, int, PlayerMark> _onValidMove;
    private event Action<PlayerMark> _onCurrentPlayer;
    private event Action<EndGameCondition, PlayerMark> _onEndGame;
    public event Action<int, int, PlayerMark> OnValidMove {
        add => _onValidMove += value;
        remove => _onValidMove -= value;
    }
    public void InvokeOnValidMove(int x, int y, PlayerMark playerMark) {
        _onValidMove?.Invoke(x, y, playerMark);
    }
    public event Action<PlayerMark> OnCurrentPlayer {
        add => _onCurrentPlayer += value;
        remove => _onCurrentPlayer -= value;
    }
    public void InvokeOnCurrentPlayer(PlayerMark playerMark) {
        Debug.Log($"Next Player: {playerMark}");
        _onCurrentPlayer?.Invoke(playerMark);
    }
    public event Action<EndGameCondition, PlayerMark> OnEndGame {
        add => _onEndGame += value;
        remove => _onEndGame -= value;
    }
    public void InvokeOnEndGame(EndGameCondition endGameCondition, PlayerMark playerMark) {
        Debug.Log($"End Game: {endGameCondition}, {playerMark}");
        _onEndGame?.Invoke(endGameCondition, playerMark);
    }
}