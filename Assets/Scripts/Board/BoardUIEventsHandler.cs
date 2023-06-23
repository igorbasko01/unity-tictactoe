using System;
using UnityEngine;

public class BoardUIEventsHandler {
    /**
        * This event is fired when a cell is clicked.
        * The first parameter is the X coordinate of the cell.
        * The second parameter is the Y coordinate of the cell.
        */
    public event Action<int, int> OnCellClicked;

    /**
        * This method is called when a cell is clicked.
        * The cellIndex parameter is the index of the cell that was clicked.
        * The index is calculated from left to right, top to bottom.
        * The top left cell has index 0, the bottom right cell has index 8.
        */
    public void CellClick(int cellIndex) {
        if (cellIndex >= 0 && cellIndex < 9)
            OnCellClicked?.Invoke(cellIndex % 3, cellIndex / 3);
    }
}