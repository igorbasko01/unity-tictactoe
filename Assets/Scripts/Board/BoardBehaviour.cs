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
        buttons[0].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(0);
        });
        buttons[1].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(1);
        });
        buttons[2].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(2);
        });
        buttons[3].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(3);
        });
        buttons[4].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(4);
        });
        buttons[5].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(5);
        });
        buttons[6].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(6);
        });
        buttons[7].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(7);
        });
        buttons[8].onClick.AddListener(() => {
            _boardUIEventsHandler.CellClick(8);
        });
    }

    public void OnCellStateChanged(int x, int y, PlayerMark playerMark) {
        var cells = GetComponentsInChildren<Button>();
        var cellButton = cells[y * 3 + x];
        var cellText = cellButton.GetComponentInChildren<TextMeshProUGUI>();
        cellText.text = playerMark == PlayerMark.X ? "X" : "O";
        cellButton.interactable = false;
    }
}
