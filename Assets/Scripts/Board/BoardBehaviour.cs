using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardBehaviour : MonoBehaviour
{
    private BoardHandlerEvents _boardHandlerEvents;
    private BoardUIEventsHandler _boardUIEventsHandler;

    public void SetBoardHandlerEvents(BoardHandlerEvents boardHandlerEvents) {
        _boardHandlerEvents = boardHandlerEvents;
        _boardHandlerEvents.OnCellStateChanged -= OnCellStateChanged;
        _boardHandlerEvents.OnCellStateChanged += OnCellStateChanged;
    }

    public void SetBoardUIEventsHandler(BoardUIEventsHandler boardUIEventsHandler) {
        _boardUIEventsHandler = boardUIEventsHandler;
        registerCellsClick();
    }

    private void registerCellsClick() {
        var buttons = GetComponentsInChildren<Button>();
        for (var i = 0; i < buttons.Length; i++) {
            var index = i;  // for closure.
            buttons[i].onClick.AddListener(() => {
                _boardUIEventsHandler.CellClick(index);
            });
        }
    }

    private void OnCellStateChanged(int x, int y, CellState cellState) {
        var cells = GetComponentsInChildren<Button>();
        var cellButton = cells[y * 3 + x];
        var cellText = cellButton.GetComponentInChildren<TextMeshProUGUI>();
        cellText.text = cellState == CellState.X ? "X" : cellState == CellState.O ? "O" : "";
        if (cellState == CellState.Empty) {
            cellButton.interactable = true;
        } else {
            cellButton.interactable = false;
        }
    }
}
