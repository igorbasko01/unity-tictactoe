using System;
using UnityEngine;
public class BoardHandlerEvents {
    private event Action<int, int, PlayerMark> _onCellStateChanged;
    public event Action<int, int, PlayerMark> OnCellStateChanged {
        add => _onCellStateChanged += value;
        remove => _onCellStateChanged -= value;
    }

    public void InvokeOnCellStateChanged(int x, int y, PlayerMark playerMark) {
        Debug.Log($"Cell state: {x}, {y}, {playerMark}");
        _onCellStateChanged?.Invoke(x, y, playerMark);
    }

}