using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardBehaviour : MonoBehaviour
{
    private BoardHandler _boardHandler;
    private BoardUIEventsHandler _boardUIEventsHandler;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoardHandler(BoardHandler boardHandler) {
        _boardHandler = boardHandler;
        _boardHandler.OnCellStateChanged -= OnCellStateChanged;
        _boardHandler.OnCellStateChanged += OnCellStateChanged;
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

    private void OnCellStateChanged(int x, int y, PlayerMark playerMark) {
        var cells = GetComponentsInChildren<Button>();
        var cellButton = cells[y * 3 + x];
        var cellText = cellButton.GetComponentInChildren<TextMeshProUGUI>();
        cellText.text = playerMark == PlayerMark.X ? "X" : "O";
        cellButton.interactable = false;
    }
}
