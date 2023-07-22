using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapBehaviour : MonoBehaviour
{
    [SerializeField] private BoardBehaviour _boardBehaviour;
    [SerializeField] private AgainButtonBehavior _againButtonBehavior;
    private GameManagerEvents _gameManagerEvents;
    private PlayerEvents _playerEvents;
    private BoardHandler _boardHandler;
    private BoardHandlerEvents _boardHandlerEvents;
    private BoardUIEventsHandler _boardUIEventsHandler;
    private GameManager _gameManager;
    private HumanPlayerHandler _humanPlayerHandler;
    private AIPlayerHandler _aiPlayerHandler;
    private IMovementLogic _aiMovementLogic;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerEvents = new GameManagerEvents();
        _boardHandlerEvents = new BoardHandlerEvents();
        _playerEvents = new PlayerEvents();
        _aiMovementLogic = new RandomMovementLogic();
        _boardHandler = new BoardHandler(_boardHandlerEvents);
        _boardUIEventsHandler = new BoardUIEventsHandler();
        _humanPlayerHandler = new HumanPlayerHandler(_boardUIEventsHandler, _playerEvents);
        _aiPlayerHandler = new AIPlayerHandler(_gameManagerEvents, _boardHandler, _playerEvents, _aiMovementLogic);
        _gameManager = new GameManager(_playerEvents, _boardHandler, _gameManagerEvents);
        _boardBehaviour.SetBoardHandlerEvents(_boardHandlerEvents);
        _boardBehaviour.SetBoardUIEventsHandler(_boardUIEventsHandler);
        _againButtonBehavior.SetGameManagerEvents(_gameManagerEvents);
        _gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
