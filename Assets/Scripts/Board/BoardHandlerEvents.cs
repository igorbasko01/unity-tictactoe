using System;
using UnityEngine;
public class BoardHandlerEvents {
    private event Action<int, int, CellState> _onCellStateChanged;
    public event Action<int, int, CellState> OnCellStateChanged {
        add => _onCellStateChanged += value;
        remove => _onCellStateChanged -= value;
    }

    public void InvokeOnCellStateChanged(int x, int y, CellState cellState) {
        Debug.Log($"Cell state: {x}, {y}, {cellState}");
        _onCellStateChanged?.Invoke(x, y, cellState);
    }

}