using NUnit.Framework;

[TestFixture]
public class GameManagerTests {
    [Test]
    public void GameManagerListensForOnPerformMoveEventFromHumanPlayer() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler, gameManagerEvents);
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
}