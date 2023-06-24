using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapBehaviour : MonoBehaviour
{
    [SerializeField] private BoardBehaviour _boardBehaviour;

    private BoardHandler _boardHandler;
    private BoardUIEventsHandler _boardUIEventsHandler;
    private GameManager _gameManager;
    private HumanPlayerHandler _humanPlayerHandler;
    // Start is called before the first frame update
    void Start()
    {
        _boardHandler = new BoardHandler();
        _boardUIEventsHandler = new BoardUIEventsHandler();
        _humanPlayerHandler = new HumanPlayerHandler(_boardUIEventsHandler);
        _gameManager = new GameManager(_humanPlayerHandler, _boardHandler);
        _boardBehaviour.SetBoardHandler(_boardHandler);
        _boardBehaviour.SetBoardUIEventsHandler(_boardUIEventsHandler);
        _gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
