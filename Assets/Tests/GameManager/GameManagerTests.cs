using NUnit.Framework;

[TestFixture]
public class GameManagerTests {
    [Test]
    public void GameManagerListensForOnPerformMoveEventFromHumanPlayer() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        gameManagerEvents.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void GameManagerPublishesOnValidMoveIfACellIsFree() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        gameManagerEvents.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void GameManagerWontPublishOnValidMoveIfCellIsOccupied() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        var numberOfInvocations = 0;
        gameManagerEvents.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
            numberOfInvocations++;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
    }

    [Test]
    public void SendCurrentPlayerEventOnGameStart() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var playerMark = PlayerMark.O;
        gameManagerEvents.OnCurrentPlayer += (nplayerMark) => {
            playerMark = nplayerMark;
        };
        gameManager.StartGame();
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void SwitchCurrentPlayerOnValidMove() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var playerMark = default(PlayerMark);
        gameManagerEvents.OnCurrentPlayer += (nplayerMark) => {
            playerMark = nplayerMark;
        };
        gameManager.StartGame();
        Assert.AreEqual(PlayerMark.X, playerMark);
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(PlayerMark.O, playerMark);
    }

    [Test]
    public void GameManagerWontPublishOnValidMoveIfPlayingPlayerNotCurrent() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        var numberOfInvocations = 0;
        gameManagerEvents.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
            numberOfInvocations++;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
        boardUIEventsHandler.CellClick(1);
        Assert.AreEqual(1, numberOfInvocations);  // still the same, means the event was not invoked
    }

    [Test]
    public void InvokeDrawEndGameCondition() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        IMovementLogic movementLogic = new FreeEmptyCellMovementLogic();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        AIPlayerHandler aiPlayerHandler = new AIPlayerHandler(gameManagerEvents, boardHandler, playerEvents, movementLogic);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var numberOfInvocations = 0;
        var playerMark = default(PlayerMark);
        var endGameCondition = default(EndGameCondition);
        gameManagerEvents.OnEndGame += (gameCondition, player) => {
            playerMark = player;
            endGameCondition = gameCondition;
            numberOfInvocations++;
        };
        gameManager.StartGame();
        boardUIEventsHandler.CellClick(4);
        boardUIEventsHandler.CellClick(3);
        boardUIEventsHandler.CellClick(1);
        boardUIEventsHandler.CellClick(2);
        boardUIEventsHandler.CellClick(8);
        Assert.AreEqual(1, numberOfInvocations);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(EndGameCondition.Draw, endGameCondition);
    }

    [Test]
    public void InvokeRowWinEndGameCondition() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        IMovementLogic movementLogic = new FreeEmptyCellMovementLogic();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        AIPlayerHandler aiPlayerHandler = new AIPlayerHandler(gameManagerEvents, boardHandler, playerEvents, movementLogic);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var numberOfInvocations = 0;
        var playerMark = default(PlayerMark);
        var endGameCondition = default(EndGameCondition);
        gameManagerEvents.OnEndGame += (gameCondition, player) => {
            playerMark = player;
            endGameCondition = gameCondition;
            numberOfInvocations++;
        };
        gameManager.StartGame();
        boardUIEventsHandler.CellClick(0);
        boardUIEventsHandler.CellClick(1);
        boardUIEventsHandler.CellClick(2);
        Assert.AreEqual(1, numberOfInvocations);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(EndGameCondition.Win, endGameCondition);
    }

    [Test]
    public void InvokeColumnWinEndGameCondition() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        IMovementLogic movementLogic = new FreeEmptyCellMovementLogic();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        AIPlayerHandler aiPlayerHandler = new AIPlayerHandler(gameManagerEvents, boardHandler, playerEvents, movementLogic);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var numberOfInvocations = 0;
        var playerMark = default(PlayerMark);
        var endGameCondition = default(EndGameCondition);
        gameManagerEvents.OnEndGame += (gameCondition, player) => {
            playerMark = player;
            endGameCondition = gameCondition;
            numberOfInvocations++;
        };
        gameManager.StartGame();
        boardUIEventsHandler.CellClick(2);
        boardUIEventsHandler.CellClick(5);
        boardUIEventsHandler.CellClick(8);
        Assert.AreEqual(1, numberOfInvocations);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(EndGameCondition.Win, endGameCondition);
    }

    [Test]
    public void InvokeDiagonalWinEndGameCondition() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        IMovementLogic movementLogic = new FreeEmptyCellMovementLogic();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        AIPlayerHandler aiPlayerHandler = new AIPlayerHandler(gameManagerEvents, boardHandler, playerEvents, movementLogic);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        var numberOfInvocations = 0;
        var playerMark = default(PlayerMark);
        var endGameCondition = default(EndGameCondition);
        gameManagerEvents.OnEndGame += (gameCondition, player) => {
            playerMark = player;
            endGameCondition = gameCondition;
            numberOfInvocations++;
        };
        gameManager.StartGame();
        boardUIEventsHandler.CellClick(0);
        boardUIEventsHandler.CellClick(4);
        boardUIEventsHandler.CellClick(8);
        Assert.AreEqual(1, numberOfInvocations);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(EndGameCondition.Win, endGameCondition);
    }
}