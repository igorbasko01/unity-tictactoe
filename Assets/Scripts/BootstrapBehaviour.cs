using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapBehaviour : MonoBehaviour
{
    [SerializeField] private BoardBehaviour _boardBehaviour;

    private GameManagerEvents _gameManagerEvents;
    private BoardHandler _boardHandler;
    private BoardHandlerEvents _boardHandlerEvents;
    private BoardUIEventsHandler _boardUIEventsHandler;
    private GameManager _gameManager;
    private HumanPlayerHandler _humanPlayerHandler;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerEvents = new GameManagerEvents();
        _boardHandlerEvents = new BoardHandlerEvents();
        _boardHandler = new BoardHandler(_boardHandlerEvents);
        _boardUIEventsHandler = new BoardUIEventsHandler();
        _humanPlayerHandler = new HumanPlayerHandler(_boardUIEventsHandler);
        // TODO: Remove the _humanPlayerHandler parameter from the GameManager constructor.
        // No need for the _humanPlayerHandler to be passed to the GameManager, as the events
        // of the human player are in the GameEvents class.
        _gameManager = new GameManager(_humanPlayerHandler, _boardHandler, _gameManagerEvents);
        _boardBehaviour.SetBoardHandlerEvents(_boardHandlerEvents);
        _boardBehaviour.SetBoardUIEventsHandler(_boardUIEventsHandler);
        _gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
