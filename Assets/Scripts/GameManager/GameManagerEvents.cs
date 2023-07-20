using System;
using UnityEngine;
public class GameManagerEvents {
    private event Action<int, int, PlayerMark> _onValidMove;
    public event Action<int, int, PlayerMark> OnValidMove {
        add => _onValidMove += value;
        remove => _onValidMove -= value;
    }
    public void InvokeOnValidMove(int x, int y, PlayerMark playerMark) {
        _onValidMove?.Invoke(x, y, playerMark);
    }
    
    private event Action<PlayerMark> _onCurrentPlayer;
    public event Action<PlayerMark> OnCurrentPlayer {
        add => _onCurrentPlayer += value;
        remove => _onCurrentPlayer -= value;
    }
    public void InvokeOnCurrentPlayer(PlayerMark playerMark) {
        Debug.Log($"Next Player: {playerMark}");
        _onCurrentPlayer?.Invoke(playerMark);
    }
}